﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine.Tests.Properties.Fakes;
using FluentAssertions;
using FsCheck;
using Xunit;

namespace CommandLine.Tests.Properties
{
    public class ParserProperties
    {
        private static readonly Parser Sut = new Parser();

        [Fact]
        public void Parsing_a_string_returns_original_string()
        {
            Prop.ForAll<string>(
                x =>
                {
                    var result = Sut.ParseArguments<Scalar_String_Mutable>(new[] { "--stringvalue", x });
                    ((Parsed<Scalar_String_Mutable>)result).Value.StringValue.ShouldBeEquivalentTo(x);
                }).QuickCheckThrowOnFailure();
        }
    }
}
