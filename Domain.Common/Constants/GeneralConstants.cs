namespace Domain.Common.Constants
{
    public static class GeneralConstants
    {
        public const int CountEvaluationAnnualConfigId = 1;

        public class Component
        {
            public const int CorporateObjectives = 1;
            public const int AreaObjectives = 2;
            public const int Competencies = 3;

            public static Dictionary<int, string> NameComponents = new Dictionary<int, string>{
                {1 , "OBJETIVOS CORPORATIVOS" },
                {2 , "OBJETIVOS DE AREA" },
                {3 , "COMPETENCIAS" }
            };
        }

        public class StatusGenerals
        {
            public const int Test = 1;
            public const int Create = 2;
            public const int Pending = 3;
            public const int InProgress = 4;
            public const int Complete = 5;
            public const int Finalized = 6;
        }

        public class Stages
        {
            public const int Evaluation = 1;
            public const int Calibration = 2;
            public const int Feedback = 3;
            public const int Approval = 4;
        }
    }
}
