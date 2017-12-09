using DesignPatternsBuilder.zad2.Interfaces;

namespace DesignPatternsBuilder.zad2
{
    public class TestFlowCreator : ConfigurabilityBase
    {
        public override ITestFlowBuilder TestCaseFlow(TestFlowBuilder<ConfigurabilityBase> mainFlow)
        {
            return mainFlow;
        }
    }

    public abstract class ConfigurabilityBase
    {
        public abstract ITestFlowBuilder TestCaseFlow(TestFlowBuilder<ConfigurabilityBase> mainFlow);
    }
}