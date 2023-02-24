namespace Domain.Common.Constants
{
    public static class GeneralConstants
    {
        public const int CountEvaluationAnnualLabelId = 1;
        public const int PointsCompetenceLabelId = 2;
        public const int CountCompetenceLabelId = 3;
        public const int ResultLabelsLabelId = 4;

        public const int MonthsToSubtract = -3;
        public class Component
        {
            public const int CorporateObjectives = 1;
            public const int AreaObjectives = 2;
            public const int Competencies = 3;

            public static Dictionary<int, string> ComponentsName = new Dictionary<int, string>{
                {CorporateObjectives , "Objetivos Corporativos" },
                {AreaObjectives , "Objetivos de area" },
                {Competencies , "Competencias" }
            };

            public static Dictionary<int, string> FileNameTemplates = new Dictionary<int, string>{
                {AreaObjectives , "Plantilla_Importacion_De_Lideres_Objetivos_Area.xlsx" },
                {Competencies , "Plantilla_Importacion_De_Lideres_Competencias.xlsx" }
            };
        }

        public class StatusIds
        {
            public const int Test = 1;
            public const int Create = 2;
            public const int Pending = 3;
            public const int InProgress = 4;
            public const int Completed = 5;
            public const int Finalized = 6;
        }

        public class Stages
        {
            public const int Evaluation = 1;
            public const int Calibration = 2;
            public const int Feedback = 3;
            public const int Approval = 4;

            public static Dictionary<int, string> StagesName = new Dictionary<int, string>{
                {Evaluation , "Evaluación" },
                {Calibration , "Calibración" },
                {Feedback , "Feedback" },
                {Approval , "Visto bueno" }
            };
        }
    }
}
