namespace SourceGenerators;

using Microsoft.CodeAnalysis;

internal static class ErrorDescriptor
{
    internal static DiagnosticDescriptor WrongUsingError => new
    (
        id: "GG001",
        title: "Wrong using statement detected",
        messageFormat: "Wrong using statement detected.",
        category: "SourceGenerators",
        DiagnosticSeverity.Error,
        isEnabledByDefault: true
    );
}