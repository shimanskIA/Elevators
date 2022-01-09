using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entities;

namespace DataLayer
{
    public class ElevatorRepository : IRepository<Elevator>
    {
        private static List<Elevator> elevator_list = new List<Elevator>();
        private static int end_index = 0;
        public int Add(Elevator obj)
        {
            obj.Id = end_index;
            end_index += 1;
            elevator_list.Add(obj);
            return obj.Id;
        }

        public void Update(Elevator el1)
        {
            var elevator = elevator_list.Find(c => c.Id == el1.Id);
            if (elevator != null)
            {
                elevator.capacity = el1.capacity;
                elevator.speed = el1.speed;
                elevator.actual_stage = el1.actual_stage;
                elevator.mode = el1.mode;
                elevator.mission_stage = el1.mission_stage;
                elevator.on_mission = el1.on_mission;
                elevator.inner_orders = el1.inner_orders;
                elevator.people_inside = el1.people_inside;
                elevator.actual_weight = el1.actual_weight;
                elevator.rides = el1.rides;
                elevator.empty_rides = el1.empty_rides;
                elevator.transported_people = el1.transported_people;
                elevator.up = el1.up;
                elevator.was_empty = elevator.was_empty;
            }
        }

        public void Update(int index, Elevator el1)
        {
            
        }

        public void Remove(int id)
        {
            elevator_list.RemoveAll(c => c.Id == id);
        }

        public void Save()
        {
        }

        public Elevator Find(int id)
        {
            return elevator_list.Find(c => c.Id == id);
        }

        public IEnumerable<Elevator> GetAll()
        {
            return elevator_list;
        }
    }
}
