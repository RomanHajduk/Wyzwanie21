namespace Wyzwanie21
{
    public class Statistics
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum {  get; private set; }
        public int Count { get; private set; }
        public float Average 
        {
            get 
            {
                if (Count == 0)
                {
                    return 0;
                }
                else 
                {
                    return Sum / Count;
                }
                
            }
        }
        public char AverageLetter 
        {
            get
            {
                switch (this.Average)
                {
                    case >= 80:
                        return 'A';
                    case >= 60:
                        return 'B';
                    case >= 40:
                        return 'C';
                    case >= 20:
                        return 'D';
                    default:
                        if (this.Count == 0)
                        {
                            return ' ';
                        }
                        else 
                        {
                            return 'E';
                        }
                        
                }
            }
        }
        
        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Min = 0;
            this.Max = 0;
        }
       

        public void AddGrade(float grade)
        {
            
            this.Sum += grade;
            if (this.Count == 0)
            {
                this.Min = 100;
                this.Min = Math.Min(grade, this.Min);
            }
            else 
            {
                this.Min = Math.Min(grade, this.Min);
            }
            this.Count++;
            this.Max = Math.Max(grade,this.Max);
        
        }

    }
}
