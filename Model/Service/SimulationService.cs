using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using System.Threading;

namespace Model.Service
{
    public class SimulationService : ISimulationService, IPeopleService
    {
        private readonly IRepository<Human> _repository;
        private readonly IRepository<Elevator> _elrepository;
        private readonly IRepository<int> _prepository;
        private readonly IRepository<byte> _outbuffer;
        private readonly IRepository<bool> _pushed_buttons;
        private readonly IRepository<FixedGenRule> _fg_repository;
        private readonly IRepository<RandomGenRule> _rg_repository;
        private readonly IRepository<SpeedTiming> _srepository;
        private readonly IRepository<Thread> _thread_pool;
        static object myObj = new object();

        public SimulationService(IRepository<Human> repository, IRepository<Elevator> elrepository, IRepository<int> prepository, IRepository<byte> outbuffer, IRepository<bool> pushed_buttons, IRepository<FixedGenRule> fg_repository, IRepository<RandomGenRule> rg_repository, IRepository<SpeedTiming> srepository, IRepository<Thread> thread_pool)
        {
            _repository = repository;
            _elrepository = elrepository;
            _prepository = prepository;
            _outbuffer = outbuffer;
            _pushed_buttons = pushed_buttons;
            _fg_repository = fg_repository;
            _rg_repository = rg_repository;
            _srepository = srepository;
            _thread_pool = thread_pool;
        }

        public int GetElevatorsCount()
        {
            IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
            return elevator_list.Count();
        }

        public List<int> GetStatusInfos()
        {
            List<int> status_data = new List<int>();
            IEnumerable<int> parameters = _prepository.GetAll();
            IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
            int time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(4);
            time = (int)(time / 1000);
            int minutes = (int)(time / 60);
            int seconds = time - minutes * 60;
            int transported_people = 0;
            for (int i = 0; i < elevator_list.Count(); i++)
            {
                transported_people += elevator_list.ElementAt(i).transported_people;
            }
            status_data.Add(minutes);
            status_data.Add(seconds);
            status_data.Add(transported_people);
            return status_data;
        }

        public List<int> GetElevatorsInfos(int i)
        {
            List<int> el_stats = new List<int>();
            IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
            el_stats.Add(elevator_list.ElementAt(i).Id);
            el_stats.Add(elevator_list.ElementAt(i).people_inside.Count());
            el_stats.Add(elevator_list.ElementAt(i).actual_stage);
            return el_stats;
        }
        public IEnumerable<Human> GetPeopleStatus()
        {
            IEnumerable<Human> list = _repository.GetAll();
            return list;
        }
        public void StartSimulation()
        {
            _prepository.Update((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond, 4);
            IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
            Thread FixedRuleMonitor = new Thread(new ThreadStart(PeopleFixedGenerator));
            FixedRuleMonitor.Start();
            _thread_pool.Add(FixedRuleMonitor);
            Thread RandomRuleMonitor = new Thread(new ThreadStart(PeopleRandomGenerator));
            RandomRuleMonitor.Start();
            _thread_pool.Add(RandomRuleMonitor);
            Thread FireAlarmMonitor = new Thread(new ThreadStart(CheckFireAlarm));
            FireAlarmMonitor.Start();
            _thread_pool.Add(FireAlarmMonitor);
            Thread PeopleThread = new Thread(new ThreadStart(SimulatePeopleActivity));
            PeopleThread.Start();
            _thread_pool.Add(PeopleThread);
            for (int i = 0; i < elevator_list.Count(); i++)
            {
                Thread ElevatorsThread = new Thread(new ParameterizedThreadStart(SimulateElevatorActivity));
                ElevatorsThread.Name = "Thread" + i.ToString();
                ElevatorsThread.Start(i);
                _thread_pool.Add(ElevatorsThread);
            }
        }

        public bool StopThreads()
        {
            bool stop = false;
            List<bool> el_state = new List<bool>();
            IEnumerable<Thread> pool = _thread_pool.GetAll();
            IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
            for (int i = 0; i < elevator_list.Count(); i++)
            {
                if (elevator_list.ElementAt(i).mission_stage == 0)
                {
                    el_state.Add(true);
                }
                else
                {
                    el_state.Add(false);
                }
            }
            if (el_state.Contains(false))
            {
                stop = false;
            }
            else
            {
                stop = true;
            }
            if (stop == true)
            {
                for (int i = 0; i < pool.Count(); i++)
                {
                    pool.ElementAt(i).Abort();
                }
            }
            return stop;
        }

        public void SimulatePeopleActivity()
        {
            while (true)
            {
                IEnumerable<int> parameters = _prepository.GetAll();
                IEnumerable<Human> people_list = _repository.GetAll();
                IEnumerable<byte> order_list = _outbuffer.GetAll();
                IEnumerable<SpeedTiming> timings = _srepository.GetAll();
                if (parameters.ElementAt(11) == 0)
                {
                    double mult = 1;
                    Monitor.Enter(myObj);
                    try
                    {
                        for (int i = 0; i < people_list.Count(); i++)
                        {
                            IEnumerable<bool> buttons_list = _pushed_buttons.GetAll();
                            for (int j = 0; j < timings.Count(); j++)
                            {
                                if (timings.ElementAt(j).activated == true)
                                {
                                    mult = timings.ElementAt(j).speed;
                                    break;
                                }
                            }
                            people_list.ElementAt(i).waiting_time = people_list.ElementAt(i).time_before_change + ((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13) - people_list.ElementAt(i).generation_time) * mult;
                            _repository.Update(people_list.ElementAt(i));
                            if (!(order_list.Contains((byte)people_list.ElementAt(i).generation_stage)) && buttons_list.ToList()[people_list.ElementAt(i).generation_stage] != true && people_list.ElementAt(i).reached_stage == false && people_list.ElementAt(i).in_elevator == false)
                            {
                                _pushed_buttons.Update(people_list.ElementAt(i).generation_stage, true);
                                _outbuffer.Add((byte)people_list.ElementAt(i).generation_stage);
                            }
                            if (people_list.ElementAt(i).delivery_time > 0)
                            {
                                int timestamp = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                                if (timestamp - people_list.ElementAt(i).delivery_time > (int)(3000 / mult))
                                {
                                    _repository.Remove(people_list.ElementAt(i).Id);
                                }
                            }
                        }
                    }
                    finally
                    {
                        Monitor.Exit(myObj);
                    }
                }
                Thread.Sleep((int)(1000 / timings.Last().speed));
            }
        }

        public void SimulateElevatorActivity(object x)
        {
            Thread ElevatorsMovement = new Thread(new ParameterizedThreadStart(SimulateElevatorMovement));
            int this_elevator = (int)x;
            ElevatorsMovement.Start(this_elevator);
            IEnumerable<SpeedTiming> timings = _srepository.GetAll();
            while (true)
            {
                IEnumerable<int> parameters = _prepository.GetAll();
                IEnumerable<Human> people_list = _repository.GetAll();
                IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
                if (parameters.ElementAt(11) == 0)
                {
                    Monitor.Enter(myObj);
                    try
                    {
                        IEnumerable<byte> order_list = _outbuffer.GetAll();
                        if (order_list.Count() > 0)
                        {
                            if (elevator_list.ElementAt(this_elevator).mission_stage == 0)
                            {
                                if (parameters.ElementAt(3) == 0)
                                {
                                    elevator_list.ElementAt(this_elevator).mission_stage = order_list.First();
                                }
                                else if (parameters.ElementAt(3) == 1)
                                {
                                    if (elevator_list.ElementAt(this_elevator).up == true)
                                    {
                                        int out_min = 21;
                                        for (int i = 0; i < order_list.Count(); i++)
                                        {
                                            if (order_list.ElementAt(i) < out_min && order_list.ElementAt(i) >= elevator_list.ElementAt(this_elevator).actual_stage)
                                            {
                                                out_min = order_list.ElementAt(i);
                                            }
                                        }
                                        if (out_min == 21)
                                        {
                                            int max_out = 0;
                                            for (int i = 0; i < order_list.Count(); i++)
                                            {
                                                if (order_list.ElementAt(i) > max_out && order_list.ElementAt(i) <= elevator_list.ElementAt(this_elevator).actual_stage)
                                                {
                                                    max_out = order_list.ElementAt(i);
                                                }
                                            }
                                            elevator_list.ElementAt(this_elevator).mission_stage = max_out;
                                        }
                                        else
                                        {
                                            elevator_list.ElementAt(this_elevator).mission_stage = out_min;
                                        }
                                    }
                                    else
                                    {
                                        int max_out = 0;
                                        for (int i = 0; i < order_list.Count(); i++)
                                        {
                                            if (order_list.ElementAt(i) > max_out && order_list.ElementAt(i) <= elevator_list.ElementAt(this_elevator).actual_stage)
                                            {
                                                max_out = order_list.ElementAt(i);
                                            }
                                        }
                                        if (max_out == 0)
                                        {
                                            int out_min = 21;
                                            for (int i = 0; i < order_list.Count(); i++)
                                            {
                                                if (order_list.ElementAt(i) < out_min && order_list.ElementAt(i) >= elevator_list.ElementAt(this_elevator).actual_stage)
                                                {
                                                    out_min = order_list.ElementAt(i);
                                                }
                                            }
                                            elevator_list.ElementAt(this_elevator).mission_stage = out_min;
                                        }
                                        else
                                        {
                                            elevator_list.ElementAt(this_elevator).mission_stage = max_out;
                                        }
                                    }
                                }
                                else if (parameters.ElementAt(3) == 2)
                                {

                                }
                                _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                _outbuffer.Remove(0);
                                order_list = _outbuffer.GetAll();
                            }
                        }
                    }
                    finally
                    {
                        Monitor.Exit(myObj);
                    }
                }
                Thread.Sleep((int)(1000 / timings.Last().speed));
            }
        }

        public void SimulateElevatorMovement(object x)
        {
            int this_elevator = (int)x;
            while (true)
            {
                IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
                double mult = 1;
                IEnumerable<SpeedTiming> timings = _srepository.GetAll();
                IEnumerable<int> parameters = _prepository.GetAll();
                if (parameters.ElementAt(11) == 0)
                {
                    int mission = elevator_list.ElementAt(this_elevator).mission_stage;
                    if (mission != 0)
                    {
                        int timestamp = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                        if (mission > elevator_list.ElementAt(this_elevator).actual_stage)
                        {
                            while (true)
                            {
                                for (int j = 0; j < timings.Count(); j++)
                                {
                                    if (timings.ElementAt(j).activated == true)
                                    {
                                        mult = timings.ElementAt(j).speed;
                                        break;
                                    }
                                }
                                if ((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13) - timestamp > (int)(((elevator_list.ElementAt(this_elevator).speed) * 1000) / mult))
                                {
                                    elevator_list.ElementAt(this_elevator).actual_stage++;
                                    Monitor.Enter(myObj);
                                    try
                                    {
                                        _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                    }
                                    finally
                                    {
                                        Monitor.Exit(myObj);
                                    }
                                    break;
                                }
                            }
                        }
                        else if (mission < elevator_list.ElementAt(this_elevator).actual_stage && elevator_list.ElementAt(this_elevator).mission_stage != 0)
                        {
                            while (true)
                            {
                                for (int j = 0; j < timings.Count(); j++)
                                {
                                    if (timings.ElementAt(j).activated == true)
                                    {
                                        mult = timings.ElementAt(j).speed;
                                        break;
                                    }
                                }
                                if ((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13) - timestamp > (int)(((elevator_list.ElementAt(this_elevator).speed) * 1000) / mult))
                                {
                                    elevator_list.ElementAt(this_elevator).actual_stage--;
                                    Monitor.Enter(myObj);
                                    try
                                    {
                                        _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                    }
                                    finally
                                    {
                                        Monitor.Exit(myObj);
                                    }
                                    break;
                                }
                            }
                        }
                        else if (mission == elevator_list.ElementAt(this_elevator).actual_stage && elevator_list.ElementAt(this_elevator).mission_stage != 0)
                        {
                            IEnumerable<Human> people_list = _repository.GetAll();
                            if (elevator_list.ElementAt(this_elevator).people_inside.Count() > 0)
                            {
                                elevator_list.ElementAt(this_elevator).rides++;
                            }
                            else
                            {
                                elevator_list.ElementAt(this_elevator).rides++;
                                elevator_list.ElementAt(this_elevator).empty_rides++;
                            }
                            for (int i = 0; i < elevator_list.ElementAt(this_elevator).people_inside.Count() && elevator_list.ElementAt(this_elevator).people_inside.Count() > 0; i++)
                            {
                                Monitor.Enter(myObj);
                                try
                                {
                                    if (_repository.Find(elevator_list.ElementAt(this_elevator).people_inside.ElementAt(i)).aim_stage == elevator_list.ElementAt(this_elevator).actual_stage)
                                    {
                                        Human human = _repository.Find(elevator_list.ElementAt(this_elevator).people_inside.ElementAt(i));
                                        human.reached_stage = true;
                                        human.in_elevator = false;
                                        human.delivery_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                                        elevator_list.ElementAt(this_elevator).actual_weight -= human.weight;
                                        elevator_list.ElementAt(this_elevator).transported_people++;
                                        _repository.Update(human);
                                        elevator_list.ElementAt(this_elevator).people_inside.Remove(elevator_list.ElementAt(this_elevator).people_inside.ElementAt(i));
                                        i--;
                                    }
                                }
                                finally
                                {
                                    Monitor.Exit(myObj);
                                }
                            }
                            Monitor.Enter(myObj);
                            try
                            {
                                people_list = _repository.GetAll();
                                for (int i = 0; i < people_list.Count(); i++)
                                {
                                    if (people_list.ElementAt(i).generation_stage == elevator_list.ElementAt(this_elevator).actual_stage && people_list.ElementAt(i).in_elevator == false && people_list.ElementAt(i).reached_stage == false)
                                    {
                                        if (elevator_list.ElementAt(this_elevator).actual_weight + people_list.ElementAt(i).weight <= elevator_list.ElementAt(this_elevator).capacity)
                                        {
                                            elevator_list.ElementAt(this_elevator).actual_weight += people_list.ElementAt(i).weight;
                                            elevator_list.ElementAt(this_elevator).inner_orders.Add(people_list.ElementAt(i).aim_stage);
                                            elevator_list.ElementAt(this_elevator).people_inside.Add(people_list.ElementAt(i).Id);
                                            people_list.ElementAt(i).in_elevator = true;
                                            _prepository.Update(parameters.ElementAt(14) + (int)(people_list.ElementAt(i).waiting_time), 14);
                                            if (people_list.ElementAt(i).waiting_time > parameters.ElementAt(15))
                                            {
                                                _prepository.Update((int)people_list.ElementAt(i).waiting_time, 15);
                                            }
                                            _repository.Update(people_list.ElementAt(i));
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                Monitor.Exit(myObj);
                            }

                            if (parameters.ElementAt(3) == 0)
                            {
                                if (elevator_list.ElementAt(this_elevator).inner_orders.Count() > 0)
                                {
                                    Monitor.Enter(myObj);
                                    try
                                    {
                                        elevator_list.ElementAt(this_elevator).mission_stage = elevator_list.ElementAt(this_elevator).inner_orders.First();
                                    }
                                    finally
                                    {
                                        Monitor.Exit(myObj);
                                    }
                                    elevator_list.ElementAt(this_elevator).was_empty = false;
                                    int order = elevator_list.ElementAt(this_elevator).inner_orders.First();
                                    while (elevator_list.ElementAt(this_elevator).inner_orders.Contains(order))
                                    {
                                        elevator_list.ElementAt(this_elevator).inner_orders.Remove(order);
                                    }
                                    Monitor.Enter(myObj);
                                    try
                                    {
                                        _pushed_buttons.Update(elevator_list.ElementAt(this_elevator).actual_stage, false);
                                        _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                    }
                                    finally
                                    {
                                        Monitor.Exit(myObj);
                                    }
                                }
                                else
                                {
                                    Monitor.Enter(myObj);
                                    try
                                    {
                                        _pushed_buttons.Update(elevator_list.ElementAt(this_elevator).actual_stage, false);
                                        elevator_list.ElementAt(this_elevator).mission_stage = 0;
                                        _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                    }
                                    finally
                                    {
                                        Monitor.Exit(myObj);
                                    }
                                }
                            }
                            else if (parameters.ElementAt(3) == 1)
                            {
                                IEnumerable<byte> order_list = _outbuffer.GetAll();
                                if (elevator_list.ElementAt(this_elevator).capacity - elevator_list.ElementAt(this_elevator).actual_weight >= 100)
                                {
                                    Monitor.Enter(myObj);
                                    try
                                    {
                                        if (elevator_list.ElementAt(this_elevator).inner_orders.Count() != 0 || order_list.Count() != 0)
                                        {
                                            if (elevator_list.ElementAt(this_elevator).up == true)
                                            {
                                                int in_min = 21;
                                                int out_min = 21;
                                                int in_max = 0;
                                                int out_max = 0;
                                                for (int i = 0; i < elevator_list.ElementAt(this_elevator).inner_orders.Count(); i++)
                                                {
                                                    if (elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) < in_min && elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) >= elevator_list.ElementAt(this_elevator).actual_stage)
                                                    {
                                                        in_min = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i);
                                                    }
                                                }
                                                for (int i = 0; i < order_list.Count(); i++)
                                                {
                                                    if (order_list.ElementAt(i) < out_min && order_list.ElementAt(i) >= elevator_list.ElementAt(this_elevator).actual_stage)
                                                    {
                                                        out_min = order_list.ElementAt(i);
                                                    }
                                                }
                                                int min = Math.Min(in_min, out_min);
                                                if (min == 21)
                                                {
                                                    for (int i = 0; i < elevator_list.ElementAt(this_elevator).inner_orders.Count(); i++)
                                                    {
                                                        if (elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) > in_max && elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) <= elevator_list.ElementAt(this_elevator).actual_stage)
                                                        {
                                                            in_max = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i);
                                                        }
                                                    }
                                                    for (int i = 0; i < order_list.Count(); i++)
                                                    {
                                                        if (order_list.ElementAt(i) > out_max && order_list.ElementAt(i) <= elevator_list.ElementAt(this_elevator).actual_stage)
                                                        {
                                                            out_max = order_list.ElementAt(i);
                                                        }
                                                    }
                                                    int max = Math.Max(in_max, out_max);
                                                    elevator_list.ElementAt(this_elevator).mission_stage = max;
                                                }
                                                else
                                                {
                                                    elevator_list.ElementAt(this_elevator).mission_stage = min;
                                                }
                                            }
                                            else
                                            {
                                                int in_max = 0;
                                                int out_max = 0;
                                                int in_min = 21;
                                                int out_min = 21;
                                                for (int i = 0; i < elevator_list.ElementAt(this_elevator).inner_orders.Count(); i++)
                                                {
                                                    if (elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) > in_max && elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) <= elevator_list.ElementAt(this_elevator).actual_stage)
                                                    {
                                                        in_max = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i);
                                                    }
                                                }
                                                for (int i = 0; i < order_list.Count(); i++)
                                                {
                                                    if (order_list.ElementAt(i) > out_max && order_list.ElementAt(i) <= elevator_list.ElementAt(this_elevator).actual_stage)
                                                    {
                                                        out_max = order_list.ElementAt(i);
                                                    }
                                                }
                                                int max = Math.Max(in_max, out_max);
                                                if (max == 0)
                                                {
                                                    for (int i = 0; i < elevator_list.ElementAt(this_elevator).inner_orders.Count(); i++)
                                                    {
                                                        if (elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) < in_min && elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) >= elevator_list.ElementAt(this_elevator).actual_stage)
                                                        {
                                                            in_min = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i);
                                                        }
                                                    }
                                                    for (int i = 0; i < order_list.Count(); i++)
                                                    {
                                                        if (order_list.ElementAt(i) < out_min && order_list.ElementAt(i) >= elevator_list.ElementAt(this_elevator).actual_stage)
                                                        {
                                                            out_min = order_list.ElementAt(i);
                                                        }
                                                    }
                                                    int min = Math.Min(in_min, out_min);
                                                    elevator_list.ElementAt(this_elevator).mission_stage = min;
                                                }
                                                else
                                                {
                                                    elevator_list.ElementAt(this_elevator).mission_stage = max;
                                                }
                                                int order;
                                                if (in_max > 0 && in_max >= out_max)
                                                {
                                                    order = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(in_max);
                                                    while (elevator_list.ElementAt(this_elevator).inner_orders.Contains(order))
                                                    {
                                                        elevator_list.ElementAt(this_elevator).inner_orders.Remove(order);
                                                    }
                                                }
                                                if (in_min < 21 && in_min <= out_min)
                                                {
                                                    order = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(in_min);
                                                    while (elevator_list.ElementAt(this_elevator).inner_orders.Contains(order))
                                                    {
                                                        elevator_list.ElementAt(this_elevator).inner_orders.Remove(order);
                                                    }
                                                }
                                                if (out_max > 0 && out_max >= in_max)
                                                {
                                                    int index = 0;
                                                    for (int i = 0; i < order_list.Count(); i++)
                                                    {
                                                        if (order_list.ElementAt(i) == out_max)
                                                        {
                                                            index = out_max;
                                                            break;
                                                        }
                                                    }
                                                    _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                                    _outbuffer.Remove(index);
                                                }
                                                if (out_min < 21 && out_min <= in_min)
                                                {
                                                    int index = 0;
                                                    for (int i = 0; i < order_list.Count(); i++)
                                                    {
                                                        if (order_list.ElementAt(i) == out_min)
                                                        {
                                                            index = out_min;
                                                            break;
                                                        }
                                                    }
                                                    _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                                    _outbuffer.Remove(index);
                                                }
                                            }
                                            _pushed_buttons.Update(elevator_list.ElementAt(this_elevator).actual_stage, false);
                                            _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                        }
                                        else
                                        {
                                            _pushed_buttons.Update(elevator_list.ElementAt(this_elevator).actual_stage, false);
                                            elevator_list.ElementAt(this_elevator).mission_stage = 0;
                                            _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                        }
                                    }
                                    finally
                                    {
                                        Monitor.Exit(myObj);
                                    }
                                }
                                else
                                {
                                    Monitor.Enter(myObj);
                                    try
                                    {
                                        if (elevator_list.ElementAt(this_elevator).inner_orders.Count() > 0)
                                        {
                                            if (elevator_list.ElementAt(this_elevator).up == true)
                                            {
                                                int in_min = 21;
                                                int in_max = 0;
                                                for (int i = 0; i < elevator_list.ElementAt(this_elevator).inner_orders.Count(); i++)
                                                {
                                                    if (elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) < in_min && elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) >= elevator_list.ElementAt(this_elevator).actual_stage)
                                                    {
                                                        in_min = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i);
                                                    }
                                                }
                                                if (in_min == 21)
                                                {
                                                    for (int i = 0; i < elevator_list.ElementAt(this_elevator).inner_orders.Count(); i++)
                                                    {
                                                        if (elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) > in_max && elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) <= elevator_list.ElementAt(this_elevator).actual_stage)
                                                        {
                                                            in_max = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i);
                                                        }
                                                    }
                                                    elevator_list.ElementAt(this_elevator).mission_stage = in_max;
                                                }
                                                else
                                                {
                                                    elevator_list.ElementAt(this_elevator).mission_stage = in_min;
                                                }
                                            }
                                            else
                                            {
                                                int in_max = 0;
                                                int in_min = 21;
                                                for (int i = 0; i < elevator_list.ElementAt(this_elevator).inner_orders.Count(); i++)
                                                {
                                                    if (elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) > in_max && elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) <= elevator_list.ElementAt(this_elevator).actual_stage)
                                                    {
                                                        in_max = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i);
                                                    }
                                                }
                                                int max = in_max;
                                                if (max == 0)
                                                {
                                                    for (int i = 0; i < elevator_list.ElementAt(this_elevator).inner_orders.Count(); i++)
                                                    {
                                                        if (elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) < in_min && elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i) >= elevator_list.ElementAt(this_elevator).actual_stage)
                                                        {
                                                            in_min = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(i);
                                                        }
                                                    }
                                                    elevator_list.ElementAt(this_elevator).mission_stage = in_min;
                                                }
                                                else
                                                {
                                                    elevator_list.ElementAt(this_elevator).mission_stage = max;
                                                }
                                                int order;
                                                if (in_max > 0)
                                                {
                                                    order = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(in_max);
                                                    while (elevator_list.ElementAt(this_elevator).inner_orders.Contains(order))
                                                    {
                                                        elevator_list.ElementAt(this_elevator).inner_orders.Remove(order);
                                                    }
                                                }
                                                if (in_min < 21)
                                                {
                                                    order = elevator_list.ElementAt(this_elevator).inner_orders.ElementAt(in_min);
                                                    while (elevator_list.ElementAt(this_elevator).inner_orders.Contains(order))
                                                    {
                                                        elevator_list.ElementAt(this_elevator).inner_orders.Remove(order);
                                                    }
                                                }
                                            }
                                            _pushed_buttons.Update(elevator_list.ElementAt(this_elevator).actual_stage, false);
                                            _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                        }
                                        else
                                        {
                                            _pushed_buttons.Update(elevator_list.ElementAt(this_elevator).actual_stage, false);
                                            elevator_list.ElementAt(this_elevator).mission_stage = 0;
                                            _elrepository.Update(elevator_list.ElementAt(this_elevator));
                                        }
                                    }
                                    finally
                                    {
                                        Monitor.Exit(myObj);
                                    }
                                }
                            }
                            else if (parameters.ElementAt(3) == 2)
                            {

                            }
                        }
                    }
                }
                Thread.Sleep((int)(1000 / timings.Last().speed));
            }
        }

        public void ActivatePause()
        {
            IEnumerable<int> parameters = _prepository.GetAll();
            int time_paused;
            if (parameters.ElementAt(11) == 0)
            {
                _prepository.Update(1, 11);
                _prepository.Update((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond, 12);
            }
            else
            {
                time_paused = parameters.ElementAt(13);
                time_paused += ((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(12));
                _prepository.Update(time_paused, 13);
                _prepository.Update(0, 11);
                IEnumerable<RandomGenRule> random_gen_rule_list = _rg_repository.GetAll();
                IEnumerable<FixedGenRule> fixed_gen_rule_list = _fg_repository.GetAll();
                for (int i = 0; i < random_gen_rule_list.Count(); i++)
                {
                    if (random_gen_rule_list.ElementAt(i).gen_while_paused == 1)
                    {
                        random_gen_rule_list.ElementAt(i).load_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - time_paused;
                        random_gen_rule_list.ElementAt(i).time_changed = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - time_paused;
                    }
                }
                for (int i = 0; i < fixed_gen_rule_list.Count(); i++)
                {
                    if (fixed_gen_rule_list.ElementAt(i).gen_while_paused == 1)
                    {
                        fixed_gen_rule_list.ElementAt(i).load_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - time_paused;
                        fixed_gen_rule_list.ElementAt(i).time_changed = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - time_paused;
                    }
                }
            }
        }

        public void PeopleFixedGenerator()
        {
            while (true)
            {
                IEnumerable<FixedGenRule> fixed_gen_rule_list = _fg_repository.GetAll();
                IEnumerable<int> parameters = _prepository.GetAll();
                double mult = 1;
                IEnumerable<SpeedTiming> timings = _srepository.GetAll();
                if (parameters.ElementAt(11) == 0)
                {
                    for (int i = 0; i < fixed_gen_rule_list.Count(); i++)
                    {
                        int time = fixed_gen_rule_list.ElementAt(i).time;
                        int gstage = fixed_gen_rule_list.ElementAt(i).generation_stage;
                        int astage = fixed_gen_rule_list.ElementAt(i).aim_stage;
                        int amount = fixed_gen_rule_list.ElementAt(i).amount_of_people;
                        int interval = fixed_gen_rule_list.ElementAt(i).interval;
                        int weight = fixed_gen_rule_list.ElementAt(i).average_weight;
                        int time_dist = fixed_gen_rule_list.ElementAt(i).time_distance;
                        bool if_multiplicated = fixed_gen_rule_list.ElementAt(i).multiplicated;
                        int changed = fixed_gen_rule_list.ElementAt(i).time_changed;
                        double old_mult = fixed_gen_rule_list.ElementAt(i).mult_old;
                        int added_count = fixed_gen_rule_list.ElementAt(i).add_count;
                        for (int j = 0; j < timings.Count(); j++)
                        {
                            if (timings.ElementAt(j).activated == true)
                            {
                                mult = timings.ElementAt(j).speed;
                                break;
                            }
                        }
                        if (fixed_gen_rule_list.ElementAt(i).passed == true)
                        {
                            fixed_gen_rule_list.ElementAt(i).time_distance += (int)((interval * 1000 / mult));
                            changed = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                            fixed_gen_rule_list.ElementAt(i).time_changed = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                            added_count = (int)((interval * 1000 / mult));
                            time_dist += (int)((interval * 1000 / mult));
                            fixed_gen_rule_list.ElementAt(i).passed = false;
                            _fg_repository.Update(fixed_gen_rule_list.ElementAt(i));
                        }
                        if (if_multiplicated == true)
                        {
                            int timestamp = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                            fixed_gen_rule_list.ElementAt(i).time_distance = fixed_gen_rule_list.ElementAt(i).time_distance - added_count + (timestamp - changed) + (int)(((added_count - (timestamp - changed)) / mult) * old_mult);
                            time_dist = fixed_gen_rule_list.ElementAt(i).time_distance;
                            added_count = (int)(((added_count - (timestamp - changed)) / mult) * old_mult);
                            fixed_gen_rule_list.ElementAt(i).time_changed = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                            fixed_gen_rule_list.ElementAt(i).multiplicated = false;
                            _fg_repository.Update(fixed_gen_rule_list.ElementAt(i));
                        }
                        //Console.WriteLine(time_dist);
                        //Console.WriteLine((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - fixed_gen_rule_list.ElementAt(i).load_time - time_dist);
                        int actual_time_gone = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13) - fixed_gen_rule_list.ElementAt(i).load_time - time_dist;
                        if (actual_time_gone >= 0 && actual_time_gone <= (int)(1000 / mult) + (int)(1000 / (5 * mult)))
                        {
                            if (parameters.ElementAt(9) == 0)
                            {
                                GeneratePeople(amount.ToString(), gstage.ToString(), astage.ToString(), weight.ToString());
                                fixed_gen_rule_list.ElementAt(i).passed = true;
                                Monitor.Enter(myObj);
                                try
                                {
                                    _fg_repository.Update(fixed_gen_rule_list.ElementAt(i));
                                }
                                finally
                                {
                                    Monitor.Exit(myObj);
                                }
                            }
                            else
                            {
                                fixed_gen_rule_list.ElementAt(i).passed = false;
                                fixed_gen_rule_list.ElementAt(i).multiplicated = true;
                                fixed_gen_rule_list.ElementAt(i).time_distance = (int)(time / mult);
                                fixed_gen_rule_list.ElementAt(i).load_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                                _fg_repository.Update(fixed_gen_rule_list.ElementAt(i));
                            }
                        }
                        fixed_gen_rule_list.ElementAt(i).add_count = added_count;
                        fixed_gen_rule_list.ElementAt(i).mult_old = mult;
                    }
                }
                Thread.Sleep((int)(1000 / timings.Last().speed));
            }
        }

        public void PeopleRandomGenerator()
        {
            while (true)
            {
                IEnumerable<SpeedTiming> timings = _srepository.GetAll();
                IEnumerable<RandomGenRule> random_gen_rule_list = _rg_repository.GetAll();
                IEnumerable<int> parameters = _prepository.GetAll();
                double mult = 1;
                if (parameters.ElementAt(11) == 0)
                {
                    for (int i = 0; i < random_gen_rule_list.Count(); i++)
                    {
                        int time = random_gen_rule_list.ElementAt(i).time;
                        int gstage = random_gen_rule_list.ElementAt(i).generation_stage;
                        int astage = random_gen_rule_list.ElementAt(i).aim_stage;
                        int amount = random_gen_rule_list.ElementAt(i).amount_of_people;
                        int weight = random_gen_rule_list.ElementAt(i).average_weight;
                        int time_dist = random_gen_rule_list.ElementAt(i).time_distance;
                        bool if_multiplicated = random_gen_rule_list.ElementAt(i).multiplicated;
                        int changed = random_gen_rule_list.ElementAt(i).time_changed;
                        double old_mult = random_gen_rule_list.ElementAt(i).mult_old;
                        int added_count = random_gen_rule_list.ElementAt(i).add_count;
                        for (int j = 0; j < timings.Count(); j++)
                        {
                            if (timings.ElementAt(j).activated == true)
                            {
                                mult = timings.ElementAt(j).speed;
                                break;
                            }
                        }
                        if (if_multiplicated == true)
                        {
                            int timestamp = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                            random_gen_rule_list.ElementAt(i).time_distance = random_gen_rule_list.ElementAt(i).time_distance - added_count + (timestamp - changed) + (int)(((added_count - (timestamp - changed)) / mult) * old_mult);
                            time_dist = random_gen_rule_list.ElementAt(i).time_distance;
                            added_count = (int)(((added_count - (timestamp - changed)) / mult) * old_mult);
                            random_gen_rule_list.ElementAt(i).time_changed = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13);
                            random_gen_rule_list.ElementAt(i).multiplicated = false;
                            _rg_repository.Update(random_gen_rule_list.ElementAt(i));
                        }
                        //Console.WriteLine(time_dist);
                        //Console.WriteLine((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - random_gen_rule_list.ElementAt(i).load_time - time_dist);
                        int actual_time_gone = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13) - random_gen_rule_list.ElementAt(i).load_time - time_dist;
                        if (actual_time_gone >= 0 && actual_time_gone <= (int)(1000 / mult) + (int)(1000 / (5 * mult)) && parameters.ElementAt(9) == 0 && random_gen_rule_list.ElementAt(i).generated == false)
                        {
                            GeneratePeople(amount.ToString(), gstage.ToString(), astage.ToString(), weight.ToString());
                            random_gen_rule_list.ElementAt(i).generated = true;
                        }
                        random_gen_rule_list.ElementAt(i).add_count = added_count;
                        random_gen_rule_list.ElementAt(i).mult_old = mult;
                    }
                }
                Thread.Sleep((int)(1000 / timings.Last().speed));
            }
        }
        public void GeneratePeople(string p1, string p2, string p3, string p4)
        {
            int amount = int.Parse(p1);
            int gstage = int.Parse(p2);
            int astage = int.Parse(p3);
            int average_weight = int.Parse(p4);
            IEnumerable<int> parameters = _prepository.GetAll();
            for (int i = 0; i < amount; i++)
            {
                _repository.Add(new Human { weight = average_weight, generation_stage = gstage, aim_stage = astage, in_elevator = false, reached_stage = false, generation_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13) });
            }
        }
        public void FireAlarmActivate()
        {
            _prepository.Update(1, 5);
        }
        public void FireAlarmDeactivate()
        {
            _prepository.Update(2, 5);
        }
        public void CheckFireAlarm()
        {
            while (true)
            {
                IEnumerable<int> parameters = _prepository.GetAll();
                IEnumerable<Elevator> elevator_list = _elrepository.GetAll();
                IEnumerable<Human> people_list = _repository.GetAll();
                IEnumerable<bool> pushed_buttons = _pushed_buttons.GetAll();
                double mult = 1;
                IEnumerable<SpeedTiming> timings = _srepository.GetAll();
                if (parameters.ElementAt(11) == 0)
                {
                    for (int j = 0; j < timings.Count(); j++)
                    {
                        if (timings.ElementAt(j).activated == true)
                        {
                            mult = timings.ElementAt(j).speed;
                            break;
                        }
                    }
                    if (parameters.ElementAt(5) == 1)
                    {
                        Monitor.Enter(myObj);
                        try
                        {
                            _prepository.Update((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13), 18);
                            _prepository.Update(parameters.ElementAt(16) + 1, 16);
                            for (int i = 0; i < pushed_buttons.Count(); i++)
                            {
                                _pushed_buttons.Update(i, false);
                            }
                        }
                        finally
                        {
                            Monitor.Exit(myObj);
                        }
                        Monitor.Enter(myObj);
                        try
                        {
                            for (int i = 0; i < people_list.Count(); i++)
                            {
                                if (people_list.ElementAt(i).in_elevator == false)
                                {
                                     _repository.Remove(people_list.ElementAt(i).Id);
                                     i--;
                                }
                                else
                                {
                                    people_list.ElementAt(i).reserve_stage = people_list.ElementAt(i).aim_stage;
                                    people_list.ElementAt(i).aim_stage = 1;
                                    _repository.Update(people_list.ElementAt(i));
                                }
                            }
                        }
                        finally
                        {
                            Monitor.Exit(myObj);
                        }
                        Monitor.Enter(myObj);
                        try
                        {
                            for (int i = 0; i < elevator_list.Count(); i++)
                            {
                                if (elevator_list.ElementAt(i).people_inside.Count() != 0)
                                {
                                    elevator_list.ElementAt(i).reserve_stage = elevator_list.ElementAt(i).mission_stage;
                                    elevator_list.ElementAt(i).mission_stage = 1;
                                }
                                else
                                {
                                    elevator_list.ElementAt(i).reserve_stage = 0;
                                    elevator_list.ElementAt(i).mission_stage = 1;
                                }
                                _elrepository.Update(elevator_list.ElementAt(i));
                            }
                        }
                        finally
                        {
                            Monitor.Exit(myObj);
                        }
                        Monitor.Enter(myObj);
                        try
                        {
                            _prepository.Update(0, 5);
                            _prepository.Update(1, 9);
                        }
                        finally
                        {
                            Monitor.Exit(myObj);
                        }
                    }
                    if (parameters.ElementAt(9) == 1 && parameters.ElementAt(19) == 1)
                    {
                        Monitor.Enter(myObj);
                        try
                        {
                            _prepository.Update(parameters.ElementAt(17) + (int)(((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13) - parameters.ElementAt(18)) * mult), 17);
                            _prepository.Update((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13), 18);
                            _prepository.Update(0, 19);
                        }
                        finally
                        {
                            Monitor.Exit(myObj);
                        }
                        parameters = _prepository.GetAll();
                    }
                    if (parameters.ElementAt(5) == 2)
                    {
                        _prepository.Update(parameters.ElementAt(17) + (int)(((DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13) - parameters.ElementAt(18)) * mult), 17);
                        for (int i = 0; i < people_list.Count(); i++)
                        {
                            people_list.ElementAt(i).aim_stage = people_list.ElementAt(i).reserve_stage;
                            people_list.ElementAt(i).reserve_stage = 0;
                            Monitor.Enter(myObj);
                            try
                            {
                                _repository.Update(people_list.ElementAt(i));
                            }
                            finally
                            {
                                Monitor.Exit(myObj);
                            }
                        }
                        Monitor.Enter(myObj);
                        try
                        {
                            for (int i = 0; i < elevator_list.Count(); i++)
                            {
                                elevator_list.ElementAt(i).mission_stage = elevator_list.ElementAt(i).reserve_stage;
                                elevator_list.ElementAt(i).reserve_stage = 0;
                                _elrepository.Update(elevator_list.ElementAt(i));

                            }
                        }
                        finally
                        {
                            Monitor.Exit(myObj);
                        }
                        Monitor.Enter(myObj);
                        try
                        {
                            _prepository.Update(0, 5);
                            _prepository.Update(0, 9);
                        }
                        finally
                        {
                            Monitor.Exit(myObj);
                        }
                    }
                }
                Thread.Sleep((int)(1000 / timings.Last().speed));
            }
        }
    }
}
