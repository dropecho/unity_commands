namespace Dropecho {
  public interface ICommandGenerator {
    ICommand GetGeneratedCommand(CommandReceiver entity);
  }
}