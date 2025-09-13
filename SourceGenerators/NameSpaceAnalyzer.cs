namespace SourceGenerators;

using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

[Generator]
public class NameSpaceAnalyzer : IIncrementalGenerator
{
    private const string ClassName = "MyClass.g.cs";
    private const string ClassBody = """
                                     namespace SourceGenerators;
                                     
                                     // using {{namespace}};
                                     
                                     public class MyClass
                                     {
                                         public MyClass()
                                         {
                                             throw new Exception("Wrong using statment detected.");
                                         }
                                     }
                                     """;

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterSourceOutput(
            context.CompilationProvider,
            (ctx, compilation) =>
            {
                ctx.AddSource(ClassName, SourceText.From(ClassBody, Encoding.UTF8));

                //ctx.ReportDiagnostic(Diagnostic.Create(ErrorDescriptor.WrongUsingError, Location.None));
            });
    }
}