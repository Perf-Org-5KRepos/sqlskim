﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CommandLine;

using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;

namespace Microsoft.CodeAnalysis.Sql
{
    internal class SqlSkim
    {
        internal static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<
                VisitOptions,
                AnalyzeOptions,
                ExportConfigurationOptions,
                ExportRulesMetadataOptions>(args)
                .MapResult(
                (VisitOptions visitOptions) => new VisitCommand().Run(visitOptions),
                (AnalyzeOptions analyzeOptions) => new AnalyzeCommand().Run(analyzeOptions),
                (ExportConfigurationOptions exportConfigurationOptions) => new ExportConfigurationCommand().Run(exportConfigurationOptions),
                (ExportRulesMetadataOptions exportRulesMetadataOptions) => new ExportRulesMetadataCommand().Run(exportRulesMetadataOptions),
                errs => 1);
        }
    }
}
