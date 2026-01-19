namespace TestRunAnything
{
    public static class Medium
    {
        public static int ReserveInteger(int x)
        {
            /*
            Given a signed 32-bit integer x, return x with its digits reversed. 
            If reversing x causes the value to go outside the signed 32-bit 
            integer range [-2^31, 2^31 - 1], then return 0.
            Assume the environment does not allow you to store 64-bit integers (signed or unsigned).
            */
            int rev = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                if (rev > int.MaxValue / 10)
                    return 0;
                if (rev < int.MinValue / 10)
                    return 0;
                rev = rev * 10 + pop;
            }
            return rev;
        }
    }
}
