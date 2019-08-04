﻿using System;
using Spruce.Attribs;
using Spruce.Tokens;
using XSharp.Tokens;
using XSharp.x86;

namespace XSharp.Emitters
{
    // Emitters does the actual translation from X# (via Spruce) to x86 (via Assemblers)
    public class AllEmitters : Emitters
    {
        public AllEmitters(Compiler aCompiler, x86.Assemblers.Assembler aAsm) : base(aCompiler, aAsm)
        {
        }

        // ===============================================================
        // Keywords

        // ===============================================================

        [Emitter(typeof(Variable), typeof(OpEquals), typeof(Variable))]
        protected void VariableAssignment(object aVariableName, string aOpEquals, object aValue)
        {
        }

        // if AL = #Vs2Ds_Noop return
        [Emitter(typeof(If), typeof(Compare), typeof(Return))]
        protected void IfConditionReturn(string aOpIf, object[] aCompareData, object aOpReturn)
        {
        }

        // if = {
        [Emitter(typeof(If), typeof(Compare), typeof(OpOpenBrace))]
        protected void IfConditionBlockStart(string aOpIf, object[] aCompareData, object aOpOpenBrace)
        {
            Compiler.Blocks.StartBlock(Compiler.BlockType.If);
        }

        // if = goto lLabel123
        [Emitter(typeof(If), typeof(Compare), typeof(GotoKeyword), typeof(Identifier))]
        protected void IfConditionGoto(string aOpIf, object[] aCompareData, string aGotoKeyword, string aLabel)
        {
        }

        // if AL = #Vs2Ds_Noop return
        [Emitter(typeof(If), typeof(Size), typeof(CompareVar), typeof(Return))]
        protected void IfConditionReturn(string aOpIf, string aSize, object[] aCompareData, object aOpReturn)
        {
        }

        // if AL = #Vs2Ds_Noop {
        [Emitter(typeof(If), typeof(Size), typeof(CompareVar), typeof(OpOpenBrace))]
        protected void IfConditionBlockStart(string aOpIf, string aSize, object[] aCompareData, object aOpOpenBrace)
        {
            Compiler.Blocks.StartBlock(Compiler.BlockType.If);
        }

        // if AL = goto lLabel123
        [Emitter(typeof(If), typeof(Size), typeof(CompareVar), typeof(GotoKeyword), typeof(Identifier))]
        protected void IfConditionGoto(string aOpIf, string aSize, object[] aCompareData, string aGotoKeyword, string aLabel)
        {
        }

        // If = return
        [Emitter(typeof(If), typeof(OpPureComparators), typeof(Return))]
        protected void IfConditionPureReturn(string aOpIf, string aPureComparator, string aReturns)
        {
        }

        [Emitter(typeof(If), typeof(OpPureComparators), typeof(OpOpenBrace))]
        protected void IfConditionPureBlockStart(string aOpIf, string aOpPureComparators, string aOpOpenBrace)
        {
            Compiler.Blocks.StartBlock(Compiler.BlockType.If);
        }

        [Emitter(typeof(If), typeof(OpPureComparators), typeof(GotoKeyword), typeof(Identifier))]
        protected void IfConditionPureGoto(string aOpIf, string aOpPureComparators, string aGotoKeyword, string aLabel)
        {
        }

        [Emitter(typeof(While), typeof(Compare), typeof(OpOpenBrace))]
        protected void WhileConditionBlockStart(string aOpWhile, object[] aCompareData, object aOpOpenBrace)
        {
            Compiler.Blocks.StartBlock(Compiler.BlockType.While);
        }

        [Emitter(typeof(While), typeof(Size), typeof(CompareWithMem), typeof(OpOpenBrace))]
        protected void WhileConditionWithMemoryBlockStart(string aOpWhile, string aSize, object[] aCompareData, object aOpOpenBrace)
        {
            Compiler.Blocks.StartBlock(Compiler.BlockType.While);
        }

        [Emitter(typeof(While), typeof(OpPureComparators), typeof(OpOpenBrace))]
        protected void WhileConditionPureBlockStart(string aOpWhile, string aOpPureComparators, string aOpOpenBrace)
        {
            Compiler.Blocks.StartBlock(Compiler.BlockType.If);
        }

        [Emitter(typeof(Repeat), typeof(Int32u), typeof(Times), typeof(OpOpenBrace))]
        protected void RepeatBlockStart(string aOpRepeat, UInt32 loops, string aOpTimes, string aOpOpenBrace)
        {
            Compiler.Blocks.StartBlock(Compiler.BlockType.Repeat);
        }

        // const i = 0
        [Emitter(typeof(ConstKeyword), typeof(Identifier), typeof(OpEquals), typeof(Int32u))]
        [Emitter(typeof(ConstKeyword), typeof(Identifier), typeof(OpEquals), typeof(StringLiteral))]
        protected void ConstDefinition(string aConstKeyword, string aConstName, string oOpEquals, object aConstValue)
        {
            Compiler.WriteLine($"{Compiler.CurrentNamespace}_Const_{aConstName} equ {aConstValue}");
        }

        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(OpEquals), typeof(Int32u))]
        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(OpEquals), typeof(StringLiteral))]
        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(OpEquals), typeof(Const))]
        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(OpEquals), typeof(Variable))]
        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(OpEquals), typeof(VariableAddress))]
        protected void VariableDefinition(string aVarKeyword, string aVariableName, string oOpEquals, object aVariableValue)
        {
        }

        [Emitter(typeof(VarKeyword), typeof(Identifier))]
        protected void VariableDefinition(string aVarKeyword, string aVariableName)
        {
            Compiler.WriteLine($"{Compiler.CurrentNamespace}_{aVariableName} dd 0");
        }

        [Emitter(typeof(VarKeyword), typeof(Identifier), typeof(Size), typeof(OpOpenBracket), typeof(Int32u), typeof(OpCloseBracket))]
        protected void VariableArrayDefinition(string aVarKeyword, string aVariableName, string aSize, string aOpOpenBracket, object aNumberOfItems, string aOpCloseBracket)
        {
        }

        [Emitter(typeof(Reg), typeof(OpBitwise), typeof(Const))]
        [Emitter(typeof(Reg), typeof(OpBitwise), typeof(Variable))]
        [Emitter(typeof(Reg08), typeof(OpBitwise), typeof(Reg08))]
        [Emitter(typeof(Reg08), typeof(OpBitwise), typeof(Int08u))]
        [Emitter(typeof(Reg16), typeof(OpBitwise), typeof(Reg16))]
        [Emitter(typeof(Reg16), typeof(OpBitwise), typeof(Int16u))]
        [Emitter(typeof(Reg32), typeof(OpBitwise), typeof(Reg32))]
        [Emitter(typeof(Reg32), typeof(OpBitwise), typeof(Int32u))]
        [Emitter(typeof(Reg32), typeof(OpBitwise), typeof(VariableAddress))]
        protected void BitwiseArithmetic(Register aRegister, string aOpBitwise, object aValue)
        {
        }

        [Emitter(typeof(Reg08), typeof(OpEquals), typeof(OpTilde), typeof(Reg08))]
        [Emitter(typeof(Reg16), typeof(OpEquals), typeof(OpTilde), typeof(Reg16))]
        [Emitter(typeof(Reg32), typeof(OpEquals), typeof(OpTilde), typeof(Reg32))]
        protected void BitwiseNot(Register aRegister, string aOpEquals, string aOpTilde, Register aSourceRegister)
        {
        }

        // interrupt iNmae123 {
        [Emitter(typeof(Interrupt), typeof(Identifier), typeof(OpOpenBrace))]
        protected void InterruptDefinitionStart(string aInterruptKeyword, string aFunctionName, string aOpOpenBrace)
        {
            if (!string.IsNullOrWhiteSpace(Compiler.CurrentFunction))
            {
                throw new Exception("Found an interrupt handler embedded inside another interrupt handler or function.");
            }

            Compiler.CurrentFunction = aFunctionName;
            Compiler.CurrentFunctionType = Compiler.BlockType.Interrupt;
            Compiler.FunctionExitLabelFound = false;

            Compiler.Blocks.Reset();

            Compiler.WriteLine($"{Compiler.CurrentNamespace}_{aFunctionName}:");
        }

        // function fName123 {
        [Emitter(typeof(FunctionKeyword), typeof(Identifier), typeof(OpOpenBrace))]
        protected void FunctionDefinitionStart(string aFunctionKeyword, string aFunctionName, string aOpOpenBrace)
        {
            if (!string.IsNullOrWhiteSpace(Compiler.CurrentFunction))
            {
                throw new Exception("Found a function definition embedded inside another interrupt handler or function.");
            }

            Compiler.CurrentFunction = aFunctionName;
            Compiler.CurrentFunctionType = Compiler.BlockType.Function;
            Compiler.FunctionExitLabelFound = false;

            Compiler.Blocks.Reset();

            Compiler.WriteLine($"{Compiler.CurrentNamespace}_{aFunctionName}:");
        }

        // }
        [Emitter(typeof(OpCloseBrace))]
        protected void BlockEnd(string opCloseBrace)
        {
            var xBlock = Compiler.Blocks.Current();
            if (xBlock != null)
            {
                switch (xBlock.Type)
                {
                    case Compiler.BlockType.If:
                    case Compiler.BlockType.While:
                    case Compiler.BlockType.Repeat:
                        string xEndLabel = $"{Compiler.CurrentNamespace}_{Compiler.CurrentFunction}_Block{xBlock.LabelID}_End:";
                        Compiler.WriteLine(xEndLabel);
                        Compiler.Blocks.EndBlock();
                        break;
                }
            }
            else
            {
                // No current block. Must be a function or interrupt.
                if (!Compiler.FunctionExitLabelFound)
                {
                    // Need to emit an 'Exit:' label.
                    string xExitLabel = $"{Compiler.CurrentNamespace}_{Compiler.CurrentFunction}_Exit";
                    Compiler.WriteLine($"{xExitLabel}:");
                    switch (Compiler.CurrentFunctionType)
                    {
                        case Compiler.BlockType.Function:
                            // TODO
                            // Asm.Emit(OpCode.Mov, "dword", new Address("INTS_LastKnownAddress"), xExitLabel);
                            Asm.Emit(OpCode.Ret);
                            break;
                        case Compiler.BlockType.Interrupt:
                            Asm.Emit(OpCode.IRet);
                            break;
                    }
                }
                Compiler.CurrentFunction = "";
                Compiler.CurrentFunctionType = Compiler.BlockType.None;
                Compiler.Blocks.Reset();
            }
        }

        [Emitter(typeof(GotoKeyword), typeof(Identifier))]
        protected void Goto(string aGotoKeyword, string aLabelName)
        {
            Asm.Emit(OpCode.Jmp, $"{Compiler.CurrentNamespace}_{Compiler.CurrentFunction}_{aLabelName}");
        }

        // Important! All that start with AlphaNum MUST be last to allow fall through to prevent early claims over keywords.
        // fName ()
        [Emitter(typeof(Identifier), typeof(OpOpenParen), typeof(OpCloseParen))]
        protected void FunctionCall(string aFunctionName, string aOpOpenParenthesis, string aOpCloseParenthesis)
        {
            Compiler.WriteLine($"Call {Compiler.CurrentNamespace}_{aFunctionName}");
        }

        // lName123:
        [Emitter(typeof(Identifier), typeof(OpColon))]
        protected void LabelDefinitionStart(string aLabelName, string aOpColon)
        {
            Compiler.CurrentLabel = aLabelName;

            if (aLabelName.ToUpper() == "EXIT")
            {
                Compiler.FunctionExitLabelFound = true;
            }

            Compiler.WriteLine($"{Compiler.CurrentNamespace}_{Compiler.CurrentFunction}_{aLabelName}:");
        }
    }
}