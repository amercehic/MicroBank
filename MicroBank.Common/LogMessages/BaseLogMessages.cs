namespace MicroBank.Common.LogMessages
{
    public class BaseLogMessages<T>
    {
        public static string PerformCreatingMessage = "Perfom creating of " + typeof(T).Name.ToString() + ": {}";
        public static string SuccessCreatingMessage = typeof(T).Name.ToString() + " successfully created with Id: {}";
        public static string PerformGetByIdMessage = "Get" + typeof(T).Name.ToString() + "with id {}";
        public static string PerformUpdatingMessage = "Update" + typeof(T).Name.ToString() + "with id {}";
        public static string PerformDeletingMessage = "Delete" + typeof(T).Name.ToString() + "with id {}";
    }
}
