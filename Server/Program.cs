using System;

using System.Collections.Generic;
//   1 1 2 3 5 
namespace Server
{

    class Preson{
        public string name="default";
    }
    class Student:Preson
    {
        private int count;

        public int age = 0;

        public Student(string s)
        {
            name = s;
        }
        public Student(int a)
        {
            age=a;
        }
        public int printName(string pre="pre"){
            count++;
            if(count>10){
                Console.WriteLine(pre+name);
            }
           return 0;
        }
    }
    class School{
        public Student[] students;
        public School(){
            students=new Student[10];
            for(int i=0;i<students.Length;i++){
                students[i]=new Student(i);
            }
        }
        public void Come(Student s){

            Student[] temp=new Student[students.Length+1];//创建长度+1的数组
            //把学校的学生放到新数组中
            for(int i=0;i<students.Length;i++){
                temp[i]=students[i];
            }
            //把新来的学生放到最后一位
            //让新数组的最后一位 等于这个新来的学生
            temp[students.Length]= s;

            //让学习的学生数组变量等于新的数组
            students=temp;
        }
        public void Leave(Student s){
            //0,1,2,3,4,5,6,7,8,9

            //0,1,2,4....
            //0,1,2,3,4,5,6,7,8$,9
            Student[] temp=new Student[students.Length-1];
            bool isfind=false;
            for(int i=0;i<students.Length;i++){
                if(students[i]==s){
                    isfind=true;
                }
                if(isfind){
                    if(i!=students.Length-1){
                        temp[i]=students[i+1];
                    }
                }else{
                    if(i!=students.Length-1){
                    temp[i]=students[i];
                    }
                }
            }
            if(isfind){
                students=temp;
            }
        }
    }
    class Program
    {


        int a;
        void print()
        {

        }
        static int count = 0;
        static void print(string s)
        {
            Console.Write(s);
        }
        static void printStudent(Student s)
        {
            string w = "学生" + s.name + "\n";

            Console.Write(w);

            s.name = "nq";
        }

        static int Add(int a, int b)
        {
            print("Add func");
            int result = a + b;
            a = 100;
            b = 100;

            return result;
        }
        static int r()
        {
            count++;
            Console.Write(count);
            if (count > 10)
            {
                return 0;
            }
            else
            {
                return r();
            }

        }


        static void Main(string[] args)
        {
            int a = 0;
            int b = a;


            string e = "abc";
            string f = e;


            Student c = new Student("zcy");

            Student n = new Student(10);
            // c=new Student();

            // Student d=c;

            // c.name="zcy";

            int z = Add(a, b);
            c.printName();
            // printStudent(c);

            // Console.Write(d.name);

            School school1=new School();
            School school2=new School();


            school2.Leave(school1.students[9]);
            
//  单目 双目 

//   +-*/

            int aaa=1+1;

            object aaaa=1;

            Preson cc=c;


            Student sss=(Student)cc;
            aaaa=c;
            aaaa=sss;
            if(aaa>0&&aaa<10){

            }
            if(aaa<0||aaa>10){
                //do
                
            }

            if(aaa>10){
                aaa++;
            }else{
                aaa--;
            }

            aaa= aaa>10?aaa+1:aaa-1;

            // ArrayList ar=new ArrayList();

            List<object> ar=new List<object>();
            ar.Add(new Student(12));
            ar.Add(new Student(12));
            ar.Add(new Student(12));



            for(int i=0;i<ar.Count;i++){
                Student tmp=(Student)ar[i];
                Console.Write(tmp.name);
            }
            ar.RemoveAt(0);
        }
        
    }
}
