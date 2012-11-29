using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace db
{
class Student
{
public String socialNumber {get;set;}
public String beganYear { get; set; }
public String userID {get;set;}
public String lastName {get;set;}
public String firstName { get; set; }
public String email { get; set; }
public Student(String[] parsedStudent) {
this.socialNumber = parsedStudent[0];
this.beganYear = parsedStudent[1];
this.userID = parsedStudent[2];
this.lastName = parsedStudent[3];
this.firstName = parsedStudent[4];
this.email = parsedStudent[5];
}
}
}
