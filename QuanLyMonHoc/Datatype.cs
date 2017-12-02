using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonHoc
{
    class Subject {
        string name;
        string code;
        int credit;
        DateTime startTime;
        DateTime endTime;
        string lectureName;

        public Subject(string name, string code, int credit, DateTime startTime, DateTime endTime, string lectureName) {
            this.name = name;
            this.code = code;
            this.credit = credit;
            this.startTime = startTime;
            this.endTime = endTime;
            this.lectureName = lectureName;
        }
        public Dictionary<string, string> getData() {
            Dictionary<string, string> retData = new Dictionary<string, string>();
            retData["name"] = this.name;
            retData["code"] = this.code;
            retData["credit"] = this.credit.ToString();
            retData["startTime"] = this.startTime.ToString();
            retData["endTime"] = this.endTime.ToString();
            retData["lectureName"] = this.lectureName;
            return retData;
        }
        public bool changeData(string[] modificationInfo) {
            if (modificationInfo.Count() == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    switch (i)
                    {
                        case 0:
                            if (modificationInfo[i] != "")
                            {
                                this.name = modificationInfo[i];
                            }
                            break;

                        case 1:
                            if (modificationInfo[i] != "")
                            {
                                this.code = modificationInfo[i];
                            }
                            break;

                        case 2:
                            if (modificationInfo[i] != "")
                            {
                                this.credit = Convert.ToInt32(modificationInfo[i]);
                            }
                            break;

                        case 3:
                            if (modificationInfo[i] != "")
                            {
                                this.startTime = Convert.ToDateTime(modificationInfo[i]);
                            }
                            break;

                        case 4:
                            if (modificationInfo[i] != "")
                            {
                                this.endTime = Convert.ToDateTime(modificationInfo[i]);
                            }
                            break;

                        case 5:
                            if (modificationInfo[i] != "")
                            {
                                this.lectureName = modificationInfo[i];
                            }
                            break;
                    }
                }
                return true;
            }
            return false;
        }
        public bool isMe(string input)
        {
            input = input.ToLower();
            try {
                int credit_input = Convert.ToInt32(input);
                if (credit == credit_input)
                    return true;

            }
            catch {
                try {
                    DateTime date_input = Convert.ToDateTime(input);
                    if (date_input.Date == startTime.Date || date_input.Date == endTime.Date)
                        return true;
                
                }
                catch {
                    if (name.ToLower().Contains(input) || code.ToLower().Contains(input) || lectureName.ToLower().Contains(input))
                    {
                        return true;
                    }
                }                
            }
           
            return false;
        }
    }    
}
