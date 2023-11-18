using StringToExpression;

Console.WriteLine(args.Single().ToExpression().Compile()(null));
