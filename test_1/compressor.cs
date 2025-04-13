namespace test_1;
using System;
using System.Text.RegularExpressions;

public class compressor
{
    public string compression(string st)
    {
        string short_st = "";
        char first_letter;
        char second_letter;
        int summ = 1;
    
        for (int i = 1; i < st.Length; i++)
        {
            first_letter = st[i-1];
            second_letter = st[i];
        
            if (first_letter == second_letter)
            {
                summ++;
            }
            else
            {
                if (summ > 1)
                {
                    short_st += first_letter.ToString() + summ.ToString();
                    summ = 1;
                }
                else
                {
                    short_st += first_letter;    
                }
                if (i == st.Length-1)
                {
                    short_st += second_letter.ToString();
                }
            }

        }
        return short_st;
    }

    public string decompression(string st)
    {
        string full_st = "";
        // char first_letter;
        // char second_letter;
        Regex regex = new Regex(@"\d+");
        MatchCollection matches = regex.Matches(st);

        if (matches.Count < 1)
        {
            Console.WriteLine("Строка не сжата!!!!");
            return st;
        }
        
        for (int i = 0; i < matches.Count; i++)
        {
            if (matches[i].Index == 0)
            {
                return null;
            }

            string letter = st[matches[i].Index-1].ToString();
            int inde = matches[i].Index;
            full_st += st[matches[i].Index-1];
            
            for (int y = 1; y < int.Parse(matches[i].Value); y++)
            {
                full_st += letter;
            }
            
            
            
        }

        if (!char.IsDigit(st[st.Length - 1]))
        {
            full_st += st[st.Length - 1];
        }
        
        
        return full_st;
    }
}