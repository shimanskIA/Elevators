using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Service
{
    public class RuleService : IRuleService
    {
        private readonly IRepository<FixedGenRule> _fg_repository;
        private readonly IRepository<RandomGenRule> _rg_repository;
        private readonly IRepository<int> _prepository;

        public RuleService(IRepository<FixedGenRule> fg_repository, IRepository<RandomGenRule> rg_repository, IRepository<int> prepository)
        {
            _fg_repository = fg_repository;
            _rg_repository = rg_repository;
            _prepository = prepository;
        }

        public void AddFixedGenRule(string time, string amount, string gstage, string astage, string interval, string weight, string _name)
        {
            IEnumerable<int> parameters = _prepository.GetAll();
            int _time = int.Parse(time);
            int _amount = int.Parse(amount);
            int _gstage = int.Parse(gstage);
            int _astage = int.Parse(astage);
            int _interval = int.Parse(interval);
            int _weight = int.Parse(weight);
            int paused = parameters.ElementAt(11);
            _fg_repository.Add(new FixedGenRule { time = _time * 1000, amount_of_people = _amount, generation_stage = _gstage, aim_stage = _astage, interval = _interval, average_weight = _weight, rule_name = _name, time_distance = _time * 1000, passed = false , load_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13), time_changed = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13), multiplicated = true, add_count = _time * 1000, mult_old = 1, gen_while_paused = paused });
        }

        public void AddRandomGenRule(string time, string amount, string gstage, string astage, string weight, string _name)
        {
            IEnumerable<int> parameters = _prepository.GetAll();
            int _time = int.Parse(time);
            int _amount = int.Parse(amount);
            int _gstage = int.Parse(gstage);
            int _astage = int.Parse(astage);
            int _weight = int.Parse(weight);
            int paused = parameters.ElementAt(11);
            _rg_repository.Add(new RandomGenRule { time = _time * 1000, amount_of_people = _amount, generation_stage = _gstage, aim_stage = _astage, average_weight = _weight, rule_name = _name, time_distance = _time * 1000, load_time = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13), time_changed = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000 + DateTime.Now.Millisecond - parameters.ElementAt(13), multiplicated = true, add_count = _time * 1000, mult_old = 1, generated = false, gen_while_paused = paused });
        }

        public void ExportLeftRule(string path, string time, string amount, string gstage, string astage, string weight, string rule_name)
        {
            StreamWriter wrt = new StreamWriter(path);
            wrt.WriteLine(time);
            wrt.WriteLine(amount);
            wrt.WriteLine(gstage);
            wrt.WriteLine(astage);
            wrt.WriteLine(weight);
            wrt.WriteLine(rule_name);
            wrt.Close();
        }

        public void ExportRightRule(string path, string time, string amount, string gstage, string astage, string interval, string weight, string rule_name)
        {
            StreamWriter wrt = new StreamWriter(path);
            wrt.WriteLine(time);
            wrt.WriteLine(amount);
            wrt.WriteLine(gstage);
            wrt.WriteLine(astage);
            wrt.WriteLine(weight);
            wrt.WriteLine(interval);
            wrt.WriteLine(rule_name);
            wrt.Close();
        }

        public List<string> ImportLeftRule(string path)
        {
            List<string> fields = new List<string>();
            StreamReader rdr = new StreamReader(path);
            string time = rdr.ReadLine();
            string amount = rdr.ReadLine();
            string gstage = rdr.ReadLine();
            string astage = rdr.ReadLine();
            string weight = rdr.ReadLine();
            string name = rdr.ReadLine();
            rdr.Close();
            fields.Add(time);
            fields.Add(amount);
            fields.Add(gstage);
            fields.Add(astage);
            fields.Add(weight);
            fields.Add(name);
            return fields;
        }

        public List<string> ImportRightRule(string path)
        {
            List<string> fields = new List<string>();
            StreamReader rdr = new StreamReader(path);
            string time = rdr.ReadLine();
            string amount = rdr.ReadLine();
            string gstage = rdr.ReadLine();
            string astage = rdr.ReadLine();
            string weight = rdr.ReadLine();
            string interval = rdr.ReadLine();
            string name = rdr.ReadLine();
            rdr.Close();
            fields.Add(time);
            fields.Add(amount);
            fields.Add(gstage);
            fields.Add(astage);
            fields.Add(interval);
            fields.Add(weight);
            fields.Add(name);
            return fields;
        }
    }
}
