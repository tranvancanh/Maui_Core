using MauiUI.Models;

namespace MauiUI.ViewModels
{
    public class FirstPageViewModel
    {
        //public ReactiveProperty<Person> Person { get; }
        //public ReactiveCommand LotteryCommand { get; }
        //public ReactiveCommand NextPageNavigationCommand { get; }

        ////使用するクラスを外部から渡す(Dependency Injection)
        //public FirstPageViewModel(INavigationService navigationService, Lottery lottery)
        //{

        //    //model層のプロパティ変更通知を受け取り代入
        //    Person = lottery.ObserveProperty(x => x.Person).ToReactiveProperty();

        //    //View層のコマンド変更を感知してModel層のメソッドをコール
        //    LotteryCommand = new ReactiveCommand();
        //    LotteryCommand.Subscribe(_ => lottery.Execution());

        //    //View層のコマンド変更を感知してページ遷移
        //    NextPageNavigationCommand = new ReactiveCommand();
        //    NextPageNavigationCommand.Subscribe(async _ => await navigationService.NavigateToSecondPage());
        //}
    }
}
