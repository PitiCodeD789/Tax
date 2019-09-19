using System;
using System.Collections.Generic;
using System.Text;
using Tax.Model.Allowance;

namespace Tax.SubService
{
    public class Allowance
    {
        private decimal checkFund;
        public decimal CheckFund
        {
            get { return checkFund; }
            set { checkFund = value; }
        }

        private decimal annualIncome;
        public decimal AnnualIncome
        {
            get { return annualIncome; }
            set { annualIncome = value; }
        }

        private decimal checkLife;
        public decimal CheckLife
        {
            get { return checkLife; }
            set { checkLife = value; }
        }

        private decimal addLifeInsure;
        public decimal AddLifeInsure
        {
            get { return addLifeInsure; }
            set { addLifeInsure = value; }
        }

        public Allowance()
        {
            checkFund = 500000;
            annualIncome = 0;
            checkLife = 100000;
            addLifeInsure = 0;
        }

        public AllowanceResult MainAllowance(AllowanceCommand command)
        {
            checkFund = command.CheckFund;
            annualIncome = command.AnnualIncome;
            decimal allowance = 0;
            decimal personalAllo = 60000;
            AllowanceResult allowanceResult = new AllowanceResult()
            {
                PersonalAllo = personalAllo
            };
            allowance += personalAllo;

            bool isSpouse = command.IsSpouse;
            int numChildPayTax = command.NumChildPayTax;
            decimal spouseAllo = Spouse(isSpouse, numChildPayTax);
            allowanceResult.SpouseAllo = spouseAllo;
            allowance += spouseAllo;

            int numChildBefor2018 = command.NumChildBefor2018;
            int numChild2018 = command.NumChild2018;
            int protege = command.Protege;
            decimal childAllo = Child(numChildBefor2018, numChild2018, protege);
            allowanceResult.ChildAllo = childAllo;
            allowance += childAllo;

            int numParental = command.NumParental;
            decimal parentalAllo = Parental(numParental);
            allowanceResult.ParentalAllo = parentalAllo;
            allowance += parentalAllo;

            int numFamilyDisabled = command.NumFamilyDisabled;
            bool isOtherDisabled = command.IsOtherDisabled;
            decimal disabledAllo = Disabled(numFamilyDisabled, isOtherDisabled);
            allowanceResult.DisabledAllo = disabledAllo;
            allowance += disabledAllo;

            decimal parentalInsureFees = command.ParentalInsureFees;
            int numCoParentalInsure = command.NumCoParentalInsure;
            decimal parentalInsureAllo = ParentalInsure(parentalInsureFees, numCoParentalInsure);
            allowanceResult.ParentalInsureAllo = parentalInsureAllo;
            allowance += parentalInsureAllo;

            decimal longevityInsurance = command.LongevityInsurance;
            decimal longevityAllo = LongevityInsure(longevityInsurance);
            allowanceResult.LongevityAllo = longevityAllo;
            allowance += longevityAllo;

            decimal lifeInsureFees = command.LifeInsureFees;
            decimal spouseLifeInsureFees = command.SpouseLifeInsureFees;
            decimal lifeAllo = LifeInsure(lifeInsureFees, spouseLifeInsureFees);
            allowanceResult.LifeAllo = lifeAllo;
            allowance += lifeAllo;

            decimal healthInsureFees = command.HealthInsureFees;
            decimal healthAllo = HealthInsure(healthInsureFees);
            allowanceResult.HealthAllo = healthAllo;
            allowance += healthAllo;

            decimal providentFund = command.ProvidentFund;
            decimal exProvidentFund = command.ExProvidentFund;
            decimal providentAllo = Provident(providentFund, exProvidentFund);
            allowanceResult.ProvidentAllo = providentAllo;
            allowance += providentAllo;

            decimal nationalFund = command.NationalFund;
            decimal nationalAllo = National(nationalFund);
            allowanceResult.NationalAllo = nationalAllo;
            allowance += nationalAllo;


        }

        public decimal National(decimal nationalFund)
        {
            decimal limitNationalFund = 13200;
            if(nationalFund > limitNationalFund)
            {
                nationalFund = limitNationalFund;
            }
            if(nationalFund > checkFund)
            {
                nationalFund = checkFund;
            }
            checkFund -= nationalFund;
            decimal nationalAllo = nationalFund;
            return nationalAllo;
        }

        public decimal Provident(decimal providentFund, decimal exProvidentFund)
        {
            decimal limitProvident = 10000;
            decimal providentAllo = providentFund - exProvidentFund;
            if(providentAllo > limitProvident)
            {
                providentAllo = limitProvident;
            }
            return providentAllo;
        }

        public decimal HealthInsure(decimal healthInsureFees)
        {
            decimal limitHealth = 15000;
            if (healthInsureFees > limitHealth)
            {
                healthInsureFees = limitHealth;
            }
            if(healthInsureFees > checkLife)
            {
                healthInsureFees = checkLife;
            }
            decimal healthAllo = healthInsureFees;
            return healthAllo;
        }

        public decimal LifeInsure(decimal lifeInsureFees, decimal spouseLifeInsureFees)
        {
            lifeInsureFees += addLifeInsure;
            if(lifeInsureFees > checkLife)
            {
                lifeInsureFees = checkLife;
            }
            checkLife -= lifeInsureFees;
            decimal limitSpouse = 10000;
            if(spouseLifeInsureFees > limitSpouse)
            {
                spouseLifeInsureFees = limitSpouse;
            }
            decimal lifeAllo = lifeInsureFees + spouseLifeInsureFees;
            return lifeAllo;
        }

        public decimal LongevityInsure(decimal longevityInsurance)
        {
            decimal limitPercent = 0.15m;
            decimal limitLongevit = 200000;
            decimal longevityAllo = longevityInsurance;
            if (longevityAllo > annualIncome * limitPercent)
            {
                longevityAllo = annualIncome * limitPercent;
            }
            if(longevityAllo > limitLongevit)
            {
                longevityAllo = limitLongevit;
            }
            if(longevityAllo > checkFund)
            {
                longevityAllo = checkFund;
            }
            checkFund -= longevityAllo;
            addLifeInsure = longevityInsurance - longevityAllo;
            return longevityAllo;
        }

        public decimal ParentalInsure(decimal parentalInsureFees, int numCoParentalInsure)
        {
            decimal limitParental = 15000;
            parentalInsureFees /= numCoParentalInsure;
            if (parentalInsureFees > limitParental)
            {
                parentalInsureFees = limitParental;
            }
            decimal parentalInsureAllo = parentalInsureFees;
            return parentalInsureAllo;
        }

        public decimal Disabled(int numFamilyDisabled, bool isOtherDisabled)
        {
            if (isOtherDisabled)
            {
                numFamilyDisabled++;
            }
            decimal disabledAllo = numFamilyDisabled * 60000;
            return disabledAllo;
        }

        public decimal Parental(int numParental)
        {
            if (numParental > 4)
            {
                numParental = 4;
            }
            decimal parentalAllo = numParental * 30000;
            return parentalAllo;
        }

        public decimal Child(int numChildBefor2018, int numChild2018, int protege)
        {
            int trueChild = numChildBefor2018 + numChild2018;
            decimal protegeAllo = 0;
            if (trueChild < 3)
            {
                protegeAllo = (trueChild + protege > 3 ? (3 - trueChild) : protege) * 30000;
            }
            decimal childAllo = 0;
            if(trueChild > 1)
            {
                if(numChildBefor2018 <= 0)
                {
                    childAllo = (numChildBefor2018 * 30000) + (numChild2018 * 30000);
                }
                else
                {
                    childAllo = 30000 + (60000 * numChild2018);
                }
            }
            else
            {
                childAllo = trueChild * 30000;
            }
            return childAllo;
        }

        public decimal Spouse(bool isSpouse, int numChildPayTax)
        {
            decimal spouseAllo = 0;
            if (isSpouse)
            {
                spouseAllo = 60000 - 30000 * numChildPayTax;
            }
            if(spouseAllo < 0)
            {
                spouseAllo = 0;
            }
            return spouseAllo;
        }
    }
}
