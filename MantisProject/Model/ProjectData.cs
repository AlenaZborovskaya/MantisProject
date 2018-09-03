using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MantisProject
{
  
        public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
            public ProjectData()
            {

            }

            public ProjectData(string name)
            {
                Name = name;
            }

            public bool Equals(ProjectData other)
            {
                if (Object.ReferenceEquals(other, null)) // если тот объект с которым мы сравниваем это null
                {
                    return false; //так как текущий объект есть и он не null
                }
                if (Object.ReferenceEquals(this, other)) // те объекты совпадают
                {
                    return true;
                }
                return Name == other.Name;
            }
        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    

        public string Name { get; set; }
        public string Description { get; set; }
            }
        }
    


