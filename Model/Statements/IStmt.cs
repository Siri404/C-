namespace Lab9.Model.Statements
{
    public interface IStmt
    {
        string toString();
        ProgramState execute(ProgramState programState);
    }
}