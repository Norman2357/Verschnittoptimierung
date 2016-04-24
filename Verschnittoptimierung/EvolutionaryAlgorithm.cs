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

            if(global.runningProcess.firstStep)
            {
                global.changeCounter = 0;
            }

            // preparations
            global.runningProcess.state = 1;
            Tools tools = new Tools();

            // display running process display
            global.Verschnittoptimierung.processRunning_gear.Visible = true;
            global.Verschnittoptimierung.processRunning_label.Visible = true;

            // change "true" to an abort requirement, for example "best solution better than 95%"
            // best solution = global.solution (is set after each step/evolutionary step)
            int rim = 100;
            while (rim > 0 && global.changeCounter < 10)
            {
                // creating a basic population
                if (global.runningProcess.firstStep)
                {
                    global.changeCounter = 0;
                    global.evolutionStep = 0;

                    tools.CleanFitnessChart();

                    global.populationSmall = new List<PopulationElement>();
                    List<int> greediesForRand = new List<int>();
                    if (!global.tournamentPopulation)
                    {
                        greediesForRand = tools.CloneList(global.chosenGreedies);
                    }
                    else
                    {
                        greediesForRand = GetTournamentGreedies(global.mue);
                    }

                    // set tournament methods too
                    if(global.tournamentGreediesOnly)
                    {
                        global.tournamentGreedyMethods = new List<int>();
                        int number = (global.mue > global.multForLambda) ? global.multForLambda : global.multForLambda;
                        global.tournamentGreedyMethods = GetTournamentGreedies(number);
                    }
                    
                    for(int i = 0; i < global.mue; i++)
                    {
                        PopulationElement element = new PopulationElement();

                        Solution solution = tools.CloneSolution(global.emptySolution);

                        // select random greedy from the selectedGreedies and set its identifier, i.e. "1" for greedy1, in global
                        int selectedGreedyPosition = global.random.Next(0, greediesForRand.Count);
                        int selectedGreedy = greediesForRand[selectedGreedyPosition];
                        greediesForRand.RemoveAt(selectedGreedyPosition);
                        global.selectedGreedy = selectedGreedy;
                        
                        // execute the greedy
                        Fill fill = new Fill();
                        element.solution = fill.Greedy(true, solution);
                        element.fitnessValue = tools.CalculateFitness(element.solution);
                        global.populationSmall.Add(element);
                    }
                    EndStepBombingAlgorithm();
                    global.runningProcess.firstStep = false;

                    if (global.runningProcess.stepType == 0)
                    {
                        global.runningProcess.state = 0;
                        break;
                    }
                }

                // creating a new population (lambda)
                for(int i = 0; i < global.populationSmall.Count; i ++)
                {
                    // clone the population element's solution
                    Solution newSolutionBase = tools.CloneSolution(global.populationSmall[i].solution);

                    // create a ranking of the boards of this solution
                    List<int> rankedBoards = CreateBoardRanking(newSolutionBase);

                    // remove rects according to the mutation rate
                    float mutationRate = global.mutationRate;
                    while(mutationRate >= 1)
                    {
                        // remove all rects from the worst board and add to collectionBoard
                            // while worst board isn't empty
                        while(newSolutionBase.BoardList[rankedBoards[rankedBoards.Count - 1]].RectList.Count > 0)
                        {
                            Rect rectToRemove = newSolutionBase.BoardList[rankedBoards[rankedBoards.Count - 1]].RectList[0];
                            newSolutionBase.BoardList[rankedBoards[rankedBoards.Count - 1]].RectList.RemoveAt(0);
                            newSolutionBase.BoardList[newSolutionBase.BoardList.Count - 1].RectList.Add(rectToRemove);
                        }
                        // remove board which was emptied from the ranked boards (so that the new last element is the weakest board again)
                        rankedBoards.RemoveAt(rankedBoards.Count - 1);
                        mutationRate -= 1;
                    }
                    if(mutationRate > 0)
                    {
                        // calculate how many have to be removed
                        int nrRectsOnBoard = newSolutionBase.BoardList[rankedBoards[rankedBoards.Count - 1]].RectList.Count;
                        int numbersToRemove = Convert.ToInt32(Math.Floor(nrRectsOnBoard * mutationRate));
                        // remove the rects left to remove (starting from the last added rect)
                        while(numbersToRemove > 0)
                        {
                            Rect rectToRemove = newSolutionBase.BoardList[rankedBoards[rankedBoards.Count - 1]].RectList[
                            newSolutionBase.BoardList[rankedBoards[rankedBoards.Count - 1]].RectList.Count - 1];
                            newSolutionBase.BoardList[rankedBoards[rankedBoards.Count - 1]].RectList.RemoveAt(
                                newSolutionBase.BoardList[rankedBoards[rankedBoards.Count - 1]].RectList.Count - 1);
                            newSolutionBase.BoardList[newSolutionBase.BoardList.Count - 1].RectList.Add(rectToRemove);
                            numbersToRemove--;
                        }
                    }
                    
                    // fill with a random greedy from the selectedGreedies list
                    // and add to large population

                    for (int j = 0; j < global.multForLambda; j++)
                    {
                        Solution newSolution = tools.CloneSolution(newSolutionBase);

                        List<int> greediesForRand = new List<int>();

                        if (!global.tournamentGreediesOnly)
                        {
                            greediesForRand = tools.CloneList(global.chosenGreedies);
                        }
                        else
                        {
                            greediesForRand = tools.CloneList(global.tournamentGreedyMethods);
                        }

                        // select random greedy from the selectedGreedies and set its identifier, i.e. "1" for greedy1, in global
                        int selectedGreedyPosition = global.random.Next(0, greediesForRand.Count);
                        int selectedGreedy = greediesForRand[selectedGreedyPosition];
                        greediesForRand.RemoveAt(selectedGreedyPosition);
                        global.selectedGreedy = selectedGreedy;

                        // execute the greedy
                        PopulationElement element = new PopulationElement();
                        Fill fill = new Fill();
                        element.solution = fill.Greedy(true, newSolution);
                        element.fitnessValue = tools.CalculateFitness(element.solution);
                        global.populationLarge.Add(element);
                    }
                }
                // old (small) population still existing, new (large) population (lambda) created
                // -> end step if singleStep
                EndStepBombingAlgorithm();

                if(global.runningProcess.stepType == 0)
                {
                    global.runningProcess.state = 0;
                    rim--;
                    break;
                }

                rim--;
                
            }
            if (global.changeCounter == 10 || rim == 0)
            {
                global.runningProcess.existing = false;
                global.mue = 0;
                global.lambda = 0;
            }
        }

        
        // selects the best element of the small and the big population together and sets global.solution to it's solution
        // then removes the best element
        public PopulationElement SelectBestElement(Boolean delete)
        {
            Base global = Base.GetInstance();
            PopulationElement bestElement = global.populationSmall[0];
            Boolean bestFoundInSmall = true;
            int positionBestFound = 0;

            for(int i = 0; i < global.populationSmall.Count; i++)
            {
                if(global.populationSmall[i].fitnessValue < bestElement.fitnessValue)
                {
                    bestElement = global.populationSmall[i];
                    bestFoundInSmall = true;
                    positionBestFound = i;
                }
            }
            for(int i = 0; i < global.populationLarge.Count; i++)
            {
                if(global.populationLarge[i].fitnessValue < bestElement.fitnessValue)
                {
                    bestElement = global.populationLarge[i];
                    bestFoundInSmall = false;
                    positionBestFound = i;
                }
            }
            if(delete && bestFoundInSmall)
            {
                global.populationSmall.RemoveAt(positionBestFound);
            }
            if(delete && !bestFoundInSmall)
            {
                global.populationLarge.RemoveAt(positionBestFound);
            }
            return (bestElement);
        }

        // selects best mue elements for the new population
        public List<PopulationElement> SelectBestXElements()
        {
            Base global = Base.GetInstance();
            List<PopulationElement> bestList = new List<PopulationElement>();
            for(int i = 0; i < global.mue; i++)
            {
                bestList.Add(SelectBestElement(true));
            }
            return bestList;
        }

        // used after the first step and after each regular step
        public void EndStepBombingAlgorithm()
        {
            Base global = Base.GetInstance();
            // set new population and delete the rest
            global.populationSmall = SelectBestXElements();
            global.populationLarge = new List<PopulationElement>();
            // set best population element of the new population
            global.bestPopulationElement = SelectBestElement(false);

            if (global.solution != global.bestPopulationElement.solution)
            {
                global.changeCounter = 0;
            }
            else
            {
                global.changeCounter++;
            }
            
            global.solution = global.bestPopulationElement.solution;

            // check for best solution and set if necessary
            Tools tools = new Tools();
            tools.CheckForBestSolution();
            
            ClassificationNumbers classificationNumbers = new ClassificationNumbers(global);
            classificationNumbers.GetAndShowAllClassificationNumbers();
            Show show = new Show(global);
            show.ShowSolution(global.solution);

            // show/update fitness chart
            global.evolutionStep++;
            global.Verschnittoptimierung.fitnessChart.Series["best"].Points.AddXY(global.evolutionStep, global.populationSmall[0].fitnessValue);
            global.Verschnittoptimierung.fitnessChart.Series["worst"].Points.AddXY(global.evolutionStep, global.populationSmall[global.populationSmall.Count - 1].fitnessValue);

            // hide running process display
            global.Verschnittoptimierung.processRunning_gear.Visible = false;
            global.Verschnittoptimierung.processRunning_label.Visible = false;
        }

        public double CalculateFilledPercentageBoard(Board board)
        {
            int filledArea = 0;
            for(int i = 0; i < board.RectList.Count; i++)
            {
                filledArea += board.RectList[i].size;
            }
            return (Convert.ToDouble(filledArea) / Convert.ToDouble(board.size));
        }

        public List<int> CreateBoardRanking(Solution solution)
        {
            // list to be sorted from best to worst filled percentage
            List<int> rankedList = new List<int>();
            // list with index of each board
            List<int> listAllBoards = new List<int>();
            for(int i = 0; i < solution.BoardList.Count - 1; i++)
            {
                listAllBoards.Add(i);
            }
            while(listAllBoards.Count > 0)
            {
                int bestIndex = 0;
                int bestIndexSolution = listAllBoards[bestIndex];
                double bestValue = CalculateFilledPercentageBoard(solution.BoardList[0]);
                for (int i = 0; i < listAllBoards.Count; i++)
                {
                    if(CalculateFilledPercentageBoard(solution.BoardList[listAllBoards[i]]) > bestValue)
                    {
                        bestIndex = i;
                        bestIndexSolution = listAllBoards[bestIndex];
                        bestValue = CalculateFilledPercentageBoard(solution.BoardList[listAllBoards[i]]);
                    }
                }
                rankedList.Add(bestIndexSolution);
                listAllBoards.RemoveAt(bestIndex);
            }
            return (rankedList);
        }

        // gets the best 'number's of tournament greedies
        // number has to be smaller than 16 or 16 (no effect)
        public List<int> GetTournamentGreedies(int number)
        {
            Base global = Base.GetInstance();
            List <SingleTournamentResult> singleTournamentResults = new List<SingleTournamentResult>();
            Tools tools = new Tools();

            for(int i = 1; i <= 16; i++)
            {
                global.selectedGreedy = i;
                SingleTournamentResult singleTournamentResult = new SingleTournamentResult();
                singleTournamentResult.greedyNr = i;

                Fill fill = new Fill();
                Solution solutionEmpty = tools.CloneSolution(global.emptySolution);
                Solution solution = fill.Greedy(true, solutionEmpty);
                int fitnessValue = tools.CalculateFitness(solution);
                singleTournamentResult.fitnessValue = fitnessValue;

                singleTournamentResults.Add(singleTournamentResult);
            }
            global.selectedGreedy = 0;

            List<int> winners = new List<int>();

            for(int i = 0; i < number; i++)
            {
                int bestIndex = 0;
                int bestGreedyNr = singleTournamentResults[0].greedyNr;
                int bestFitnessValue = singleTournamentResults[0].fitnessValue;
                for(int j = 0; j < singleTournamentResults.Count; j++)
                {
                    if(singleTournamentResults[j].fitnessValue < bestFitnessValue)
                    {
                        bestIndex = j;
                        bestGreedyNr = singleTournamentResults[j].greedyNr;
                        bestFitnessValue = singleTournamentResults[j].fitnessValue;
                    }
                }
                winners.Add(bestGreedyNr);
                singleTournamentResults.RemoveAt(bestIndex);
            }
            return winners;
        }


    }
}
