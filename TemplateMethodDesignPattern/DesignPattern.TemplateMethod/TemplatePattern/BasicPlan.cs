namespace DesignPattern.TemplateMethod.TemplatePattern
{
    public class BasicPlan : NetflixPlans
    {
        public override string Content(string content)
        {
            return content;
        }

        public override int CountPerson(int countperson)
        {
            return countperson;
        }

        public override string PlanType(string plantype)
        {
            return plantype;
        }

        public override double Price(double price)
        {
            return price;
        }

        public override string Resolution(string resolution)
        {
            return resolution;
        }
    }
}
