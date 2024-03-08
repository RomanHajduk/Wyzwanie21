namespace Wyzwanie21
{
    public abstract class Person
    {
        public string Name { get; private set; }
        public string Lastname {  get; private set; }
        public int Age { get; private set; }
        public char Sex {  get; private set; }
        public Person(string name, string lastname,int age,char sex) 
        { 
            this.Name = name;
            this.Lastname = lastname;
            this.Age = age;
            this.Sex = sex;
        } 
    }
}
