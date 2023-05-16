    namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Department
    {
        private List<Room> rooms;
        private string name;

        public Department(string name)
        {
            this.name = name;
            this.rooms = new List<Room>();
            for (int i = 0; i < 20; i++)
            {
                rooms.Add(new Room(i + 1));
            }
        }

        public string Name
        {
            get { return this.name; }
           
        }

        public void AddPatientToRoom(Patient patient)
        {
            Room room = rooms.FirstOrDefault(r => r.Patients.Count < 3);

            if (room != null)
            {
                room.AddPatient(patient);
            }
        }

        public string GetAllPatients()
        {
            return string.Join(Environment.NewLine, this.rooms.SelectMany(r => r.Patients).Select(p => p.Name).ToList());
        }

        public string GetPatientsByRoom(int id)
        {
            return String.Join(Environment.NewLine, this.rooms.Single(r => r.Id == id).Patients.Select(p => p.Name).OrderBy(p => p));
        }
    }
}
