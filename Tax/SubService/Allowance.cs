using System;
using System.Collections.Generic;
using System.Text;
using Tax.Model.Allowance;

namespace Tax.SubService
{
    public class Allowance
    {
        private readonly OtherService _otherService = new OtherService();

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

        private decimal checkShop;
        public decimal CheckShop
        {
            get { return checkShop; }
            set { checkShop = value; }
        }


        public Allowance()
        {
            checkFund = 500000;
            annualIncome = 0;
            checkLife = 100000;
            addLifeInsure = 0;
            checkShop = 15000;
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
            decimal lifeAllo = LifeInsure(lifeInsureFees, spouseLifeInsureFees, isSpouse);
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

            decimal payRMF = command.PayRMF;
            decimal rmfAllo = RMF(payRMF);
            allowanceResult.RMFAllo = rmfAllo;
            allowance += rmfAllo;

            decimal payLTF = command.PayLTF;
            decimal ltfAllo = LTF(payLTF);
            allowanceResult.LTFAllo = ltfAllo;
            allowance += payLTF;

            decimal payInterestHouse = command.PayInterestHouse;
            decimal numCoBorrower = command.NumCoBorrower;
            decimal interestHouseAllo = InterestHouse(payInterestHouse, numCoBorrower);
            allowanceResult.InterestHouseAllo = interestHouseAllo;
            allowance += interestHouseAllo;

            decimal firstHouse2015Fee = command.FirstHouse2015Fee;
            decimal firstHouse2015Allo = FirstHouse2015(firstHouse2015Fee);
            allowanceResult.FirstHouse2015Allo = firstHouse2015Allo;
            allowance += firstHouse2015Allo;

            decimal firstHouse2019Fee = command.FirstHouse2019Fee;
            decimal firstHouse2019Allo = FirstHouse2019(firstHouse2015Fee, firstHouse2019Fee);
            allowanceResult.FirstHouse2019Allo = firstHouse2019Allo;
            allowance += firstHouse2019Allo;

            decimal socialSecurityFee = command.SocialSecurityFee;
            decimal socialSecurityAllo = SocialSecurity(socialSecurityFee);
            allowanceResult.SocialSecurityAllo = socialSecurityAllo;
            allowance += socialSecurityAllo;

            decimal securityCameraFee = command.SecurityCameraFee;
            decimal annualIncomeExcentOneOrTwo = command.AnnualIncomeExcentOneOrTwo;
            decimal securityCameraAllo = SecurityCamera(securityCameraFee, annualIncomeExcentOneOrTwo);
            allowanceResult.SecurityCameraAllo = securityCameraAllo;
            allowance += securityCameraAllo;

            decimal creditFee = command.CreditFee;
            decimal creditAllo = Credit(creditFee, annualIncomeExcentOneOrTwo);
            allowanceResult.CreditAllo = creditAllo;
            allowance += creditAllo;

            decimal mainTown = command.MainTown;
            decimal subTown = command.SubTown;
            decimal tourAllo = Tour(mainTown, subTown);
            allowanceResult.TourAllo = tourAllo;
            allowance += tourAllo;

            decimal startupFee = command.StartupFee;
            decimal startupAllo = Startup(startupFee);
            allowanceResult.StartupAllo = startupAllo;
            allowance += startupAllo;

            decimal antenatalFee = command.AntenatalFee;
            decimal antenatalAllo = Antenatal(antenatalFee);
            allowanceResult.AntenatalAllo = antenatalAllo;
            allowance += antenatalAllo;

            decimal politicalPartyDonate = command.PoliticalPartyDonate;
            decimal politicalPartyAllo = PoliticalParty(politicalPartyDonate);
            allowanceResult.PoliticalPartyAllo = politicalPartyAllo;
            allowance += politicalPartyAllo;

            decimal tireFee = command.TireFee;
            decimal tireAllo = ShopTire(tireFee);
            allowanceResult.TireAllo = tireAllo;
            allowance += tireAllo;

            decimal bookFee = command.BookFee;
            decimal bookAllo = ShopBook(bookFee);
            allowanceResult.BookAllo = bookAllo;
            allowance += bookAllo;

            decimal otopFee = command.OTOPFee;
            decimal otopAllo = ShopOTOP(otopFee);
            allowanceResult.OTOPAllo = otopAllo;
            allowance += otopAllo;

            allowanceResult.AllowanceValue = allowance;

            return allowanceResult;
        }

        public decimal ShopOTOP(decimal otopFee)
        {
            decimal otopAllo = _otherService.MoreThan(otopFee, checkShop);
            checkShop -= otopAllo;
            return otopAllo;
        }

        public decimal ShopBook(decimal bookFee)
        {
            decimal bookAllo = _otherService.MoreThan(bookFee, checkShop);
            checkShop -= bookAllo;
            return bookAllo;
        }

        public decimal ShopTire(decimal tireFee)
        {
            decimal tireAllo = _otherService.MoreThan(tireFee, checkShop);
            checkShop -= tireAllo;
            return tireAllo;
        }

        public decimal PoliticalParty(decimal politicalPartyDonate)
        {
            decimal limitPolitical = 10000;
            decimal politicalPartyAllo = _otherService.MoreThan(politicalPartyDonate, limitPolitical);
            return politicalPartyAllo;
        }

        private decimal Antenatal(decimal antenatalFee)
        {
            decimal antenatalAllo = antenatalFee;
            return antenatalAllo;
        }

        public decimal Startup(decimal startupFee)
        {
            decimal limitStartup = 100000;
            decimal startupAllo = _otherService.MoreThan(startupFee, limitStartup);
            return startupAllo;
        }

        public decimal Tour(decimal mainTown, decimal subTown)
        {
            decimal limitMain = 15000;
            decimal limitSub = 20000;
            mainTown = _otherService.MoreThan(mainTown, limitMain);
            decimal tourAllo = mainTown + subTown;
            tourAllo = _otherService.MoreThan(tourAllo, limitSub);
            return tourAllo;
        }

        public decimal Credit(decimal creditFee, decimal annualIncomeExcentOneOrTwo)
        {
            decimal creditAllo = _otherService.MoreThan(creditFee, annualIncomeExcentOneOrTwo);
            return creditAllo;
        }

        public decimal SecurityCamera(decimal securityCameraFee, decimal annualIncomeExcentOneOrTwo)
        {
            decimal securityCameraAllo = _otherService.MoreThan(securityCameraFee, annualIncomeExcentOneOrTwo);
            return securityCameraAllo;
        }

        public decimal SocialSecurity(decimal socialSecurityFee)
        {
            decimal limitSocialSecurity = 9000;
            var socialSecurityAllo = _otherService.MoreThan(socialSecurityFee, limitSocialSecurity);
            return socialSecurityAllo;
        }

        public decimal FirstHouse2019(decimal firstHouse2015Fee, decimal firstHouse2019Fee)
        {
            decimal limitHouse2019 = 200000;
            decimal firstHouse2019Allo = _otherService.MoreThan(firstHouse2019Fee, limitHouse2019);
            if(firstHouse2019Fee > 5000000 || firstHouse2015Fee > 0)
            {
                firstHouse2019Allo = 0;
            }
            return firstHouse2019Allo;
        }

        public decimal FirstHouse2015(decimal firstHouse2015Fee)
        {
            decimal firstHouse2015Allo = (firstHouse2015Fee * 0.2m) / 5;
            if(firstHouse2015Fee > 3000000)
            {
                firstHouse2015Allo = 0;
            }
            return firstHouse2015Allo;
        }

        public decimal InterestHouse(decimal payInterestHouse, decimal numCoBorrower)
        {
            decimal limitInterestHouse = 100000;
            decimal interestHouseAllo = 0;
            if(payInterestHouse > 0)
            {
                payInterestHouse = _otherService.MoreThan(payInterestHouse, limitInterestHouse);
                interestHouseAllo = payInterestHouse / numCoBorrower;
            }
            return interestHouseAllo;
        }

        public decimal LTF(decimal payLTF)
        {
            decimal limitPercent = 0.15m;
            if (payLTF > annualIncome * limitPercent)
            {
                payLTF = limitPercent;
            }
            decimal limitLTF = 500000;
            if(payLTF > limitLTF)
            {
                payLTF = limitLTF;
            }
            decimal ltfAllo = payLTF;
            return ltfAllo;
        }

        public decimal RMF(decimal payRMF)
        {
            decimal limitPercent = 0.15m;
            if(payRMF > limitPercent)
            {
                payRMF = limitPercent;
            }
            if(payRMF > checkFund)
            {
                payRMF = checkFund;
            }
            checkFund -= payRMF;
            decimal rmfAllo = payRMF;
            return rmfAllo;
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

        public decimal LifeInsure(decimal lifeInsureFees, decimal spouseLifeInsureFees, bool isSpouse)
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
            if (!isSpouse)
            {
                spouseLifeInsureFees = 0;
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
            decimal parentalInsureAllo = 0;
            if (parentalInsureFees > 0)
            {
                parentalInsureFees /= numCoParentalInsure;
                if (parentalInsureFees > limitParental)
                {
                    parentalInsureFees = limitParental;
                }
                parentalInsureAllo = parentalInsureFees;
            }
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
