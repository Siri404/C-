using System.Text;
using Lab9.Model.Statements;
using Lab9.Model.Util;

namespace Lab9.Model
{
    public class ProgramState
    {
        private ExeStack<IStmt> _exeStack;
        private Output<int> _output;
        private SymTable<string, int> _symTable;
        private FileTable _fileTable;
        private IStmt _program;

        public ProgramState(ExeStack<IStmt> exeStack, Output<int> output, SymTable<string, int> symTable,
            FileTable fileTable, IStmt program)
        {
            _exeStack = exeStack;
            _output = output;
            _symTable = symTable;
            _fileTable = fileTable;
            _program = program;
        }
        
        public ProgramState(IStmt statement)
        {
            _exeStack = new ExeStack<IStmt>();
            _exeStack.Push(statement);
            _symTable = new SymTable<string, int>();
            _output = new Output<int>();
            _fileTable = new FileTable();
            _program = statement;
        }

        public ExeStack<IStmt> getExeStack()
        {
            return _exeStack;
        }

        public Output<int> getOutput()
        {
            return _output;
        }

        public SymTable<string, int> getSymTable()
        {
            return _symTable;
        }

        public FileTable getFileTable()
        {
            return _fileTable;
        }

        public IStmt getProgram()
        {
            return _program;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .AppendLine("Execution Stack:")
                .AppendLine(_exeStack.ToString())
                .AppendLine("Symtable:")
                .AppendLine(_symTable.ToString())
                .AppendLine("Output:")
                .AppendLine(_output.ToString())
                .AppendLine("FileTable:")
                .AppendLine(_fileTable.ToString())
                .AppendLine("Program:")
                .AppendLine(_program.toString())
                .AppendLine()
                .AppendLine()
                .AppendLine()
                .AppendLine();
            return stringBuilder.ToString();
        }
    }
}