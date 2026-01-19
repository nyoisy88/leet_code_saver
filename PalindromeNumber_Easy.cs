namespace TestRunAnything
{
    internal class PalindromeNumber_Easy
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int temp = x;
            int rev = 0;
            while (temp > 0)
            {
                rev = rev * 10 + temp % 10;
                temp /= 10;
            }
            return rev == x;
        }
    }
}
