using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Strategy
{
    public class StrategyFunctionality
    {
        #region Methods

        public string ComponentInformation(string componentName)
        {
            string result;
            Compound water = new RichCompound("Water");
            result = water.Display();
            Compound benzene = new RichCompound("Benzene");
            result += benzene.Display();
            Compound ethanol = new RichCompound("Ethanol");
            result += ethanol.Display();

            return result;
        }

        #endregion
    }

    internal class Compound
    {
        #region Fields and Constants

        protected float _boilingPoint;
        protected string _chemical;
        protected float _meltingPoint;
        protected string _molecularFormula;
        protected double _molecularWeight;

        #endregion

        #region Constructors and Destructors

        public Compound(string chemical)
        {
            this._chemical = chemical;
        }

        #endregion

        #region Public Methods

        public virtual string Display()
        {
            return $"\nCompound: {this._chemical} ------ "; ;
        }
        #endregion
    }

    internal class RichCompound : Compound
    {
        #region Fields and Constants

        private ChemicalDatabank _bank;

        #endregion

        #region Constructors and Destructors
        public RichCompound(string name) : base(name)
        {
        }

        #endregion

        #region Public Methods
        public override string Display()
        {
            this._bank = new ChemicalDatabank();
            this._boilingPoint = this._bank.GetCriticalPoint(this._chemical, "B");
            this._meltingPoint = this._bank.GetCriticalPoint(this._chemical, "M");
            this._molecularWeight = this._bank.GetMolecularWeight(this._chemical);
            this._molecularFormula = this._bank.GetMolecularStructure(this._chemical);

            StringBuilder componentInfoBuilder = new StringBuilder();
            componentInfoBuilder.Append(base.Display());
            componentInfoBuilder.Append($" Formula: {this._molecularFormula}");
            componentInfoBuilder.Append($" Weight : {this._molecularWeight}");
            componentInfoBuilder.Append($" Melting Pt: {this._meltingPoint}");
            componentInfoBuilder.Append($" Boiling Pt: {this._boilingPoint}");

            return componentInfoBuilder.ToString();
        }

        #endregion
    }
    internal class ChemicalDatabank
    {
        #region Public Methods
        public float GetCriticalPoint(string compound, string point)
        {
            if (point == "M")
            {
                switch (compound.ToLower())
                {
                    case "water":
                        return 0.0f;
                    case "benzene":
                        return 5.5f;
                    case "ethanol":
                        return -114.1f;
                    default:
                        return 0f;
                }
            }

            switch (compound.ToLower())
            {
                case "water":
                    return 100.0f;
                case "benzene":
                    return 80.1f;
                case "ethanol":
                    return 78.3f;
                default:
                    return 0f;
            }
        }

        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water":
                    return "H20";
                case "benzene":
                    return "C6H6";
                case "ethanol":
                    return "C2H5OH";
                default:
                    return "";
            }
        }

        public double GetMolecularWeight(string compound)
        {
            switch (compound.ToLower())
            {
                case "water":
                    return 18.015;
                case "benzene":
                    return 78.1134;
                case "ethanol":
                    return 46.0688;
                default:
                    return 0d;
            }
        }

        #endregion
    }
}