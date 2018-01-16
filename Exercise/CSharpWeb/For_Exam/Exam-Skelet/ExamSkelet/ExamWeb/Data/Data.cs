namespace ExamWeb.Data
{
    public class Data
    {
        private static ExamWebContext context;

        public static ExamWebContext Context 
            => context ?? (context = new ExamWebContext());
    }
}
