using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verschnittoptimierung
{
    public class EvolutionaryAlgorithm
    {
        public EvolutionaryAlgorithm()
        {

        }
        public void BombingAlgorithm()
        {
            Base global = Base.GetInstance();
            ClassificationNumbers classificationNumbers = new ClassificationNumbers(global);

            // preparations
            global.runningProcess.state = 1;
            Tools tools = new Tools();

            // change "true" to an abort requirement, for example "best solution better than 95%"
            // best solution = global.solution (is set after each step/evolutionary step)
            while (true)
            {
                // creating a basic population
                if(global.runningProcess.firstStep)
                {
                    global.populationSmall = new List<PopulationElement>();
                    
                    for(int i = 0; i < global.mue; i++)
                    {
                        PopulationElement element = new PopulationElement();

                        Solution solution = tools.CloneSolution(global.solution);

                        
                    }
                }






            }
        }
    }
}
