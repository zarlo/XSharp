﻿using System;
using System.Collections.Generic;
using System.Text;
using Spruce.Tokens;

namespace XSharp.Tokens {
  public abstract class Reg : IdList {
    // Must use overloads. Optional param is shorter but does not provide a
    // parameterless ctor for Activator.
    protected Reg(string[] aList) : base(aList) { }
  }

  public class Reg08 : Reg {
    public Reg08() : base(x86.Params.Reg08.Names) { }
  }

  public class Reg16 : Reg {
    public Reg16() : base(x86.Params.Reg16.Names) { }
  }

  public class Reg32 : Reg {
    public Reg32() : base(x86.Params.Reg32.Names) { }
  }
}