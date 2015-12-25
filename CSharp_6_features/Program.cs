using System;
using System.Threading.Tasks;

namespace CSharp_6_features
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestClass();

            test.SomethingChaged += Test_SomethingChaged;

            var stringFormat = $"Test text here {test.IntProperty} and here {test.FirstName} ho ho";

            var nameOfClass = nameof(test.FirstName);
            
        }

        private static void Test_SomethingChaged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class TestClass
    {
        public event EventHandler SomethingChaged;

        public int IntProperty { get; set; } = 5;
        public string FirstName { get; set; } = "Sergii";

        // Not sure is this usefull
        public string GetSomeData() => $"ho ho {FirstName}!";

        public void SomethingHappned()
        {
            SomethingChaged?.Invoke(this, EventArgs.Empty);
        }

        public async Task StartAnalyzingData()
        {
            try
            {
                throw new Exception("message");             
            }
            catch(Exception exception) when (exception.Message == "ho ho")
            {
                await LogExceptionDetailsAsync();
            }
            catch (ArgumentNullException ex) when (ex.Source == "EmployeeCreation")
            {
                //Нотификация об ошибке
            }
            finally
            {
                await LogExceptionDetailsAsync();
            }
        }

        public Task LogExceptionDetailsAsync()
        {
            return new Task(() => { Console.WriteLine("test"); });
        }
    }
}
