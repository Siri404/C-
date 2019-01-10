using System.Collections.Generic;
using Lab9.Model;

namespace Lab9.Repository
{
    public interface IRepository
    {
        List<ProgramState> GetPrgList();
        void LogPrgStateExec(ProgramState state);
    }
}