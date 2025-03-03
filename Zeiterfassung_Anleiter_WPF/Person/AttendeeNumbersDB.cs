using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung_Anleiter_WPF.Person
{
    class AttendeeNumbersDB
    {
        private int attendeeID = 0;
        private string attendeeNumber = "";
        private int? fk_persons_id = null;
        private bool isSet = false;

        public int AttendeeID
        {
            get { return attendeeID; }
            set { attendeeID = value; }
        }
        public string AttendeeNumber
        {
            get { return attendeeNumber; }
            set { attendeeNumber = value; }
        }

        public int? FkPersonsID
        {
            get { return fk_persons_id; }
            set { fk_persons_id = value; }
        }

        public bool IsSet
        {
            get { return isSet; }
            set { isSet = value; }
        }
    }
}
