using System;
namespace ServiceTrackerApp
{
    public class Goals
    {
        private float DailyGoal { get; set; }
        private float DailyActual { get; set; }
        private float MonthlyGoal { get; set; }
        private float MonthlyActual { get; set; }
        private float YearlyGoal { get; set; }
        private float YearlyActual { get; set; }
        private string tid { get; set; }

        public Goals()
        {
            this.DailyGoal = 0;
            this.DailyActual = 0;
            this.MonthlyGoal = 0;
            this.MonthlyActual = 0;
            this.YearlyGoal = 0;
            this.YearlyActual = 0;
            this.tid = "";
                
        }

        public void SetDailyGoals (float DailyGoal)
        {
            this.DailyGoal = DailyGoal;
        }

        public void SetDailyActual (float DailyActual)
        {
            this.DailyActual = DailyActual;
        }

        public void SetMonthlyGoal (float MonthlyGoal)
        {
            this.MonthlyGoal = MonthlyGoal;
        }

        public void SetMonthlyActual (float MonthlyActual)
        {
            this.MonthlyActual = MonthlyActual;
        }

        public void SetYearlyGoal (float YearlyGoal)
        {
            this.YearlyGoal = YearlyGoal;
        }

        public void SetYearlyActual (float YearlyActual)
        {
            this.YearlyActual = YearlyActual;
        }

        public void SetTid (string tid)
        {
            this.tid = tid;
        }

        public float GetDailyGoal()
        {
            return this.DailyGoal;
        }

        public float GetDailyActual()
        {
            return this.DailyActual;
        }

        public float GetMonthlyGoal()
        {
            return this.MonthlyGoal;
        }

        public float GetMonthlyActual()
        {
            return this.MonthlyActual;
        }

        public float GetYearlyGoal()
        {
            return this.YearlyGoal;
        }

        public float GetYearlyActual()
        {
            return this.YearlyActual;
        }

        public string GetTid(string tid)
        {
            return this.tid;
        }
    }
}
