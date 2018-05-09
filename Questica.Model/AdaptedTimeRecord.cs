using System;
using System.Collections;
using System.Linq;

namespace Questica.Model
{
    public class AdaptedTimeRecord : IEnumerable
    {
        // Fields
        private TimeCardEntry[] _entries;
        private Objective _objective;

        // Methods
        public AdaptedTimeRecord()
        {
            this._entries = new TimeCardEntry[14];
        }

        public AdaptedTimeRecord(Objective objective, Employee employee)
        {
            this._entries = new TimeCardEntry[14];
            this.Objective = objective;
            this.Project = this.Objective.Project;
            this.Employee = employee;
        }

        private TimeCardEntry createNewTimeEntry(decimal value)
        {
            TimeCardEntry item = new TimeCardEntry
            {
                HourTime = value,
                EmpNumber = this.Employee.EmpNumber
            };
            this.Objective.Entries.Add(item);
            this.Employee.Entries.Add(item);
            return item;
        }

        public IEnumerator GetEnumerator() =>
            this._entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

        // Properties
        public Employee Employee { get; set; }

        public decimal Fri1
        {
            get
            {
                if (this._entries[6] != null)
                {
                    return this._entries[6].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[6] == null)
                {
                    this._entries[6] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[6].HourTime = value;
                }
            }
        }

        public decimal Fri2
        {
            get
            {
                if (this._entries[13] != null)
                {
                    return this._entries[13].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[13] == null)
                {
                    this._entries[13] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[13].HourTime = value;
                }
            }
        }

        public TimeCardEntry this[int index]
        {
            get =>
                this._entries[index];
            set
            {
                this._entries[index] = value;
            }
        }

        public decimal Mon1
        {
            get
            {
                if (this._entries[2] != null)
                {
                    return this._entries[2].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[2] == null)
                {
                    this._entries[2] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[2].HourTime = value;
                }
            }
        }

        public decimal Mon2
        {
            get
            {
                if (this._entries[9] != null)
                {
                    return this._entries[9].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[9] == null)
                {
                    this._entries[9] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[9].HourTime = value;
                }
            }
        }

        public Objective Objective
        {
            get =>
                this._objective;
            set
            {
                if (this._objective != null)
                {
                    for (int i = 0; i < 14; i++)
                    {
                        if (this[i] != null)
                        {
                            this._objective.Entries.Remove(this[i]);
                            if (value != null)
                            {
                                value.Entries.Add(this[i]);
                            }
                        }
                    }
                }
                this._objective = value;
            }
        }

        public Project Project { get; set; }

        public decimal Sat1
        {
            get
            {
                if (this._entries[0] != null)
                {
                    return this._entries[0].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[0] == null)
                {
                    this._entries[0] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[0].HourTime = value;
                }
            }
        }

        public decimal Sat2
        {
            get
            {
                if (this._entries[7] != null)
                {
                    return this._entries[7].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[7] == null)
                {
                    this._entries[7] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[7].HourTime = value;
                }
            }
        }

        public decimal Sun1
        {
            get
            {
                if (this._entries[1] != null)
                {
                    return this._entries[1].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[1] == null)
                {
                    this._entries[1] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[1].HourTime = value;
                }
            }
        }

        public decimal Sun2
        {
            get
            {
                if (this._entries[8] != null)
                {
                    return this._entries[8].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[8] == null)
                {
                    this._entries[8] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[8].HourTime = value;
                }
            }
        }

        public decimal Thu1
        {
            get
            {
                if (this._entries[5] != null)
                {
                    return this._entries[5].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[5] == null)
                {
                    this._entries[5] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[5].HourTime = value;
                }
            }
        }

        public decimal Thu2
        {
            get
            {
                if (this._entries[12] != null)
                {
                    return this._entries[12].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[12] == null)
                {
                    this._entries[12] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[12].HourTime = value;
                }
            }
        }

        public decimal Total =>
            (from entry in this._entries
                where entry != null
                select entry).Sum<TimeCardEntry>(((Func<TimeCardEntry, decimal>)(entry => entry.HourTime)));

        public decimal Tue1
        {
            get
            {
                if (this._entries[3] != null)
                {
                    return this._entries[3].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[3] == null)
                {
                    this._entries[3] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[3].HourTime = value;
                }
            }
        }

        public decimal Tue2
        {
            get
            {
                if (this._entries[10] != null)
                {
                    return this._entries[10].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[10] == null)
                {
                    this._entries[10] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[10].HourTime = value;
                }
            }
        }

        public decimal Wed1
        {
            get
            {
                if (this._entries[4] != null)
                {
                    return this._entries[4].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[4] == null)
                {
                    this._entries[4] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[4].HourTime = value;
                }
            }
        }

        public decimal Wed2
        {
            get
            {
                if (this._entries[11] != null)
                {
                    return this._entries[11].HourTime;
                }
                return 0M;
            }
            set
            {
                if (this._entries[11] == null)
                {
                    this._entries[11] = this.createNewTimeEntry(value);
                }
                else
                {
                    this._entries[11].HourTime = value;
                }
            }
        }
    }
}