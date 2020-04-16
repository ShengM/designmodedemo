using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.解释器模式
{
  public abstract class NodeBase
  {
    public abstract string Interpret();
  }

  public class AndNode : NodeBase
  {
    private NodeBase _left;
    private NodeBase _right;

    public AndNode(NodeBase left, NodeBase right)
    {
      _left = left;
      _right = right;
    }

    public override string Interpret()
    {
      return $"{_left.Interpret()}再{_right.Interpret()}";
    }
  }

  public class SentenceNode : NodeBase
  {
    private NodeBase _direction;
    private NodeBase _action;
    private NodeBase _distance;

    public SentenceNode(NodeBase direction, NodeBase action, NodeBase distance)
    {
      _direction = direction;
      _action = action;
      _distance = distance;
    }

    public override string Interpret()
    {
      return $"{_direction.Interpret()}{_action.Interpret()}{_distance.Interpret()}";
    }
  }

  public class DirectionNode : NodeBase
  {
    private string _direction;

    public DirectionNode(string direction)
    {
      _direction = direction;
    }

    public override string Interpret()
    {
      switch (_direction)
      {
        case "up":
          return "向上";
        case "down":
          return "向下";
        case "left":
          return "向左";
        case "right":
          return "向右";
        default:
          return "无效指令";
      }
    }
  }

  public class ActionNode : NodeBase
  {
    private string _action;

    public ActionNode(string action)
    {
      _action = action;
    }

    public override string Interpret()
    {
      switch (_action)
      {
        case "move":
          return "移动";
        case "run":
          return "快速移动";
        default:
          return "无效指令";
      }
    }
  }

  public class DistanceNode : NodeBase
  {
    private string _distance;

    public DistanceNode(string distance)
    {
      _distance = distance;
    }

    public override string Interpret()
    {
      return _distance;
    }
  }

  public class InstructionHandler
  {
    private static readonly InstructionHandler _instance = new InstructionHandler();

    private InstructionHandler()
    {
    }

    public static InstructionHandler GetInstance()
    {
      return _instance;
    }

    public NodeBase ParseInstruction(string instruction)
    {
      if (string.IsNullOrWhiteSpace(instruction))
      {
        return null;
      }

      var tokens = instruction.Split(" ");
      var stack = new Stack<NodeBase>();
      var i = 0;
      while (i < tokens.Length)
      {
        var token = tokens[i];
        if (token != "and")
        {
          var direction = new DirectionNode(token);
          var action = new ActionNode(tokens[i + 1]);
          var distance = new DistanceNode(tokens[i + 2]);
          stack.Push(new SentenceNode(direction, action, distance));
          i += 3;
        }
        else
        {
          var direction = new DirectionNode(tokens[i + 1]);
          var action = new ActionNode(tokens[i + 2]);
          var distance = new DistanceNode(tokens[i + 3]);
          var and = new AndNode(stack.Pop(), new SentenceNode(direction, action, distance));
          stack.Push(and);
          i += 4;
        }
      }
      return stack.Pop();
    }
  }

  public class Starter : IStart
  {
    public void Run()
    {
      var handler = InstructionHandler.GetInstance();
      var instruction = "up move 5 and down run 10 and left move 5";
      var node = handler.ParseInstruction(instruction);
      Console.WriteLine(node.Interpret());
    }
  }
}
