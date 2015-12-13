namespace VolleyballLeagueManagement.Common.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Check if number is even number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsEvenNumber(this int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Get half value of number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetHalf(this int number)
        {
            return number / 2;
        }
    }
}
