using System;
using System.Collections.Generic;
using System.IO;
using Lab9.Model;

namespace Lab9.Repository
{
    public class Repository: IRepository
    {
        private List<ProgramState> list;
        string log;
        public Repository(string log)
        {
            this.list = new List<ProgramState>();
            this.log = log;
        }
        List<ProgramState> IRepository.GetPrgList()
        {
            return this.list;
        }

        void IRepository.LogPrgStateExec(ProgramState state)
        {
            File.AppendAllText(this.log, state.ToString());
            Console.WriteLine(state.ToString());
        }
    }
}