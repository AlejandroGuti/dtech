using dTech.Common.Responses;
using dTech.Domain.Services.Interfaces;
using System;

namespace dTech.Domain.Services
{
    public class NumberService : INumberService
    {
        public Response BinaryGap(int Number)
        {
            char[] result = (Convert.ToString(Number, 2)).ToCharArray();
            int count = 0;
            int max = 0;
            bool Band = false;
            for (int i = result.Length - 1; i >= 0; i--)
            {
                if (result[result.Length - 1].ToString() == "0" && Band == false)
                {
                    if (result[i].ToString() == "0") { continue; }
                }
                Band = true;
                if (result[i].ToString() == "0" && Band == true)
                {
                    count += 1;
                    if (count > max) { max = count; }
                }
                else { count = 0; }
            }
            foreach (char item in result)
            {


            }

            if (max != 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = "That number have a Binary Gab: " + max

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "That number don't have a Binary Gab"
                };
            }
        }
    }
}
