using CalculadoraDifal.Entities.Enums;

namespace CalculadoraDifal.Entities
{
    class Contributor
    {
        public string State { get; set; }
        public ContributorType ContributorType { get; set; }

        public Contributor()
        {
        }

        public Contributor(string state, ContributorType contributorType)
        {
            State = state;
            ContributorType = contributorType;
        }
    }
}
