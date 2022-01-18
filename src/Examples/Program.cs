namespace bbv.Examples
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            ExecutionOption option;

            do
            {
                option = ChoseExecutionOption();

                ChangeConsoleColor();

                switch (option)
                {
                    case ExecutionOption.SrpViolation:
                        SOLID._1_SRP.I_Violation.Execution.Run();
                        break;

                    case ExecutionOption.SrpSolution:
                        SOLID._1_SRP.II_Solution.Execution.Run();
                        break;

                    case ExecutionOption.OcpViolation:
                        SOLID._2_OCP.I_Violation.Execution.Run();
                        break;

                    case ExecutionOption.OcpSolution:
                        SOLID._2_OCP.II_Solution.Execution.Run();
                        break;

                    case ExecutionOption.LspViolation:
                        SOLID._3_LSP.I_Violation.Execution.Run();
                        break;

                    case ExecutionOption.LspSolution:
                        SOLID._3_LSP.II_Solution.Execution.Run();
                        break;

                    case ExecutionOption.IspViolation:
                        SOLID._4_ISP.I_Violation.Execution.Run();
                        break;

                    case ExecutionOption.IspSolution:
                        SOLID._4_ISP.II_Solution.Execution.Run();
                        break;

                    case ExecutionOption.DipViolation:
                        SOLID._5_DIP.I_Violation.Execution.Run();
                        break;

                    case ExecutionOption.DipSolution:
                        SOLID._5_DIP.II_Solution.Execution.Run();
                        break;

                    case ExecutionOption.None:
                        Console.WriteLine("Aborted!");
                        break;
                }

                ResetConsoleColor();
            }
            while (option != ExecutionOption.None);
        }

        private static void ChangeConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(string.Empty);
        }

        private static void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(string.Empty);
        }

        private static ExecutionOption ChoseExecutionOption()
        {
            WriteSelectionOptions();
            return GetSelectedOption();
        }

        private static void WriteSelectionOptions()
        {
            Console.WriteLine(
                "Select one of the following demo executions:\r\n" +
                " 1. SRP Violation\r\n" +
                " 2. SRP Solution\r\n" +
                " 3. OCP Violation\r\n" +
                " 4. OCP Solution\r\n" +
                " 5. LSP Violation\r\n" +
                " 6. LSP Solution\r\n" +
                " 7. ISP Violation\r\n" +
                " 8. ISP Solution\r\n" +
                " 9. DIP Violation\r\n" +
                "10. DIP Solution\r\n" +
                "\r\n" +
                "Your selection (1-10): ");
        }

        private static ExecutionOption GetSelectedOption()
        {
            string input = Console.ReadLine();
            int selected;

            if (int.TryParse(input, out selected))
            {
                if (selected >= 1 && selected <= 10)
                {
                    return (ExecutionOption) selected;
                }
            }

            return ExecutionOption.None;
        }

        private enum ExecutionOption
        {
            None = 0,
            SrpViolation = 1,
            SrpSolution = 2,
            OcpViolation = 3,
            OcpSolution = 4,
            LspViolation = 5,
            LspSolution = 6,
            IspViolation = 7,
            IspSolution = 8,
            DipViolation = 9,
            DipSolution = 10
        }
    }
}