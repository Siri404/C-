using System;
using System.Collections.Generic;
using System.IO;
using Lab9.Model;
using Lab9.Model.Expressions;
using Lab9.Model.Statements;
using Lab9.Controller;
using Lab9.Repository;
using Lab9.View;

namespace Lab9
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IStmt ex1 = new CompStmt(
                                new OpenRFile("var_f","file1.txt"),
                                new CompStmt(
                                        new ReadFile(new VarExp("var_f"), "var_c"),
                                        new CompStmt(
                                                new PrintStmt(new VarExp("var_c")),
                                                new CompStmt(
                                                        new IfStmt( new VarExp("var_c"), new CompStmt(new ReadFile(new VarExp("var_f"), "var_c"),new PrintStmt(new VarExp("var_c"))),
                                                                new PrintStmt(new ConstExp(0))),
                                                        new CloseRFile(new VarExp("var_f")))
                                        )));
                        
                
            IStmt ex2= new CompStmt(new OpenRFile("var_f","file1.txt"),
                    new CompStmt( new ReadFile(new VarExp("var_f"), "var_c"),
                            new IfStmt(new VarExp("var_f"),new CompStmt(new ReadFile(new VarExp("var_f"), "var_c"),
                                    new PrintStmt(new VarExp("var_c"))),
                                    new PrintStmt(new ConstExp(0)))));
    
            
            IStmt ex3 = new CompStmt(
                    new AssignStmt("a",
                            new ArithExp('-',
                                    new ConstExp(2),
                                    new BooleanExp(
                                            new ConstExp(2),
                                            new ConstExp(3),
                                            "<"
                                    ))),
                    new CompStmt(
                            new IfStmt(
                                    new BooleanExp(
                                            new VarExp("a"),
                                            new ConstExp(1),
                                            ">"
                                    ),
                                    new AssignStmt("v",
                                            new ConstExp(2)),
                                    new AssignStmt("v",
                                            new ConstExp(3))),
                            new PrintStmt(new VarExp("v"))));
            
                
                       
               
			TextMenu menu = new TextMenu(new Dictionary<string, Command>(new Dictionary<string, Command>()));

			menu.AddCommand(new ExitCommand("0", "exit"));
			menu.AddCommand(new RunCommand("1", ex1.toString(),
				CreateController(ex1,
					"D:\\Labs\\Sem III\\MAP\\Lab9\\Lab9\\Lab9\\log.txt")));
			menu.AddCommand(new RunCommand("2", ex2.toString(),
				CreateController(ex2,
					"D:\\Labs\\Sem III\\MAP\\Lab9\\Lab9\\Lab9\\log.txt")));
			menu.AddCommand(new RunCommand("3", ex3.toString(),
				CreateController(ex3,
					"D:\\Labs\\Sem III\\MAP\\Lab9\\Lab9\\Lab9\\log.txt")));
//			menu.AddCommand(new RunCommand("4", ex4.ToString(),
//				CreateController(ex4,
//					"D:\\Labs\\Sem III\\MAP\\Lab9\\Lab9\\Lab9\\log.txt")));

			menu.show();
		}

		static Controller.Controller CreateController(IStmt stmt, string log)
		{
			IRepository repo = new Repository.Repository(log);
			Controller.Controller ctrl = new Controller.Controller(repo);
			ctrl.SetMain(new ProgramState(stmt));
			return ctrl;
		}
	}
}
