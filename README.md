# Nulab.Backlog.Api

これは Nulab 社の Backlog API を .NET で使うためのライブラリ(以下、"当 API")です。

## 要件

Bulab.Backlog.Api を使用するには、.NET Core 3.1 が必須です。

## クイックスタート

以下のコマンドを実行して NuGet からインストールしてください。

```
dotnet add package Nulab.Backlog.Api
```

当 API を使用するには、以下の名前空間が必要です。

```cs
using Nulab.Backlog.Api;
using Nulab.Backlog.Api.Data.Responses;
```

認証ユーザー情報を取得する場合は次のようなコードになります。

```cs
using System;
using System.Threading.Tasks;
using Nulab.Backlog.Api;
using Nulab.Backlog.Api.Data.Responses;

namespace Examples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Client client = new Client("https://<your backlog page url>.backlog.com");
            client.AddCredentials(new ApiTokenCredentials("<your backlog api token>"));

            BacklogResponse<LoginUser> response = await client.Users.GetMySelfAsync();
            LoginUser loginUser = response.Content;

            Console.WriteLine($"ID:{loginUser.id}, Name:{loginUser.name}, MailAddress:{loginUser.mailAddress}");
        }
    }
}
```

### クライアント操作

Backlog API を呼び出すには`IBacklogClient`を実装した`Client`クラスを使用します。
`IBacklogClient`インターフェースには、Web API の役割ごとに分類された各インターフェースをプロパティとして保持しています。
それぞれのインターフェースから呼び出すことのできる Web API については[API 一覧](#API一覧)を参照してください。

- [IUsers](./src/Nulab.Backlog.Api/IUsers.cs): `/api/v2/users`関連の Backlog API を呼び出します。
- [IProjects](./src/Nulab.Backlog.Api/IProjects.cs): `/api/v2/projects`関連の Backlog API を呼び出します。
- [ISpace](./src/Nulab.Backlog.Api/ISpace.cs): `/api/v2/space`関連の Backlog API を呼び出します。
- [IConfigurations](./src/Nulab.Backlog.Api/IConfigurations.cs): 設定関連の Backlog API を呼び出します。

## API一覧

| タイトル(リンク) | 説明 | メソッド | URL | API | 対応 |
|:----------------|:-----|:---------|:----|:----|:-----|
| [スペース情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-space/) | スペースの情報を取得します。 | GET | /api/v2/space | ✔ | [ISpace.GetAsync](./src/Nulab.Backlog.Api/ISpace.cs) |
| [最近の更新の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-recent-updates/) | スペース上で行われた最近の更新の一覧を取得します。 | GET | /api/v2/space/activities | ✔ | [ISpace.GetActivitiesAsync](./src/Nulab.Backlog.Api/ISpace.cs) |
| [スペースアイコン画像の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-space-logo/) | スペースのアイコン画像を取得します。 | GET | /api/v2/space/image |  |  |
| [スペースのお知らせの取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-space-notification/) | スペースのお知らせの情報を取得します。 | GET | /api/v2/space/notification | ✔ | [ISpace.GetNotificationAsync](./src/Nulab.Backlog.Api/ISpace.cs) |
| [スペースのお知らせの更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-space-notification/) | スペースのお知らせの情報を更新します。 | PUT | /api/v2/space/notification | ✔ | [ISpace.PutNotificationAsync](./src/Nulab.Backlog.Api/ISpace.cs) |
| [スペースの容量使用状況の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-space-disk-usage/) | スペースの容量使用状況の情報を取得します。 | GET | /api/v2/space/diskUsage | ✔ | [ISpace.GetDiskUsageAsync](./src/Nulab.Backlog.Api/ISpace.cs) |
| [添付ファイルの送信](https://developer.nulab.com/ja/docs/backlog/api/2/post-attachment-file/) | 課題、コメントまたはWikiに添付するファイルを送信し、添付ファイルに発行されたIDを取得します。 | POST | /api/v2/space/attachment |  |  |
| [ユーザー一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-user-list/) | スペースのユーザーの一覧を取得します。 | GET | /api/v2/users | ✔ | [IUsers.GetListAsync](./src/Nulab.Backlog.Api/IUsers.cs) |
| [ユーザー情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-user/) | ユーザー情報を取得します。 | GET | /api/v2/users/:userId | ✔ | [IUsers.GetAsync](./src/Nulab.Backlog.Api/IUsers.cs) |
| [ユーザーの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-user/) | スペースに新しいユーザーを追加します。<br/>プロジェクト管理者は管理者権限のユーザを追加することは出来ません。<br/>新プランのスペースではこのAPIを利用できません。 | POST | /api/v2/users |  |  |
| [ユーザーの更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-user/) | ユーザーの情報を更新します。<br/>新プランのスペースではこのAPIを利用できません。 | PATCH | /api/v2/users/:userId |  |  |
| [ユーザーの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-user/) | ユーザーをスペースから削除します。<br/>新プランのスペースではこのAPIを利用できません。 | DELETE | /api/v2/users/:userId |  |  |
| [認証ユーザー情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-own-user/) | APIとの認証に使用しているユーザーの情報を取得します。 | GET | /api/v2/users/myself | ✔ | [IUsers.GetMySelfAsync](./src/Nulab.Backlog.Api/IUsers.cs) |
| [ユーザーアイコンの取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-user-icon/) | ユーザーのアイコン画像を取得します。 | GET | /api/v2/users/:userId/icon |  |  |
| [ユーザーの最近の活動の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-user-recent-updates/) | ユーザーの最近の活動の一覧を取得します。 | GET | /api/v2/users/:userId/activities | ✔ | [IUsers.GetActivitiesAsync](./src/Nulab.Backlog.Api/IUsers.cs) |
| [ユーザーの受け取ったスター一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-received-star-list/) | ユーザーの受け取ったスターの一覧を取得します。 | GET | /api/v2/users/:userId/stars | ✔ | [IUsers.GetStarsAsync](./src/Nulab.Backlog.Api/IUsers.cs) |
| [ユーザーの受け取ったスターの数の取得](https://developer.nulab.com/ja/docs/backlog/api/2/count-user-received-stars/) | ユーザーの受け取ったスターの数を取得します。 | GET | /api/v2/users/:userId/stars/count | ✔ | [IUsers.GetStarsCountAsync](./src/Nulab.Backlog.Api/IUsers.cs) |
| [自分が最近見た課題一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-recently-viewed-issues/) | APIとの認証に使用しているユーザーが最近見た課題の一覧を取得します。 | GET | /api/v2/users/myself/recentlyViewedIssues | ✔ | [IUsers.GetRecentlyViewedIssuesAsync](./src/Nulab.Backlog.Api/IUsers.cs) |
| [自分が最近見たプロジェクト一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-recently-viewed-projects/) | APIとの認証に使用しているユーザーが最近見たプロジェクトの一覧を取得します。 | GET | /api/v2/users/myself/recentlyViewedProjects | ✔ | [IUsers.GetRecentlyViewedProjectsAsync](./src/Nulab.Backlog.Api/IUsers.cs) |
| [自分が最近見たWiki一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-recently-viewed-wikis/) | APIとの認証に使用しているユーザーが最近見たWikiの一覧を取得します。 | GET | /api/v2/users/myself/recentlyViewedWikis | ✔ | [IUsers.GetRecentlyViewedWikisAsync](./src/Nulab.Backlog.Api/IUsers.cs) |
| [プロジェクトの状態一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-status-list-of-project/) | プロジェクト固有の課題に設定できる状態一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/statuses | ✔ | [IProjects.GetStatuesAsync](./src/Nulab.Backlog.Api/IProjects.cs) |
| [優先度一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-priority-list/) | 課題に設定できる優先度の一覧を取得します。 | GET | /api/v2/priorities | ✔ | [IConfigurations.GetPrioritiesAsync](./src/Nulab.Backlog.Api/IConfigurations.cs) |
| [完了理由一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-resolution-list/) | 課題に設定できる完了理由の一覧を取得します。 | GET | /api/v2/resolutions | ✔ | [IConfigurations.GetResolutionsAsync](./src/Nulab.Backlog.Api/IConfigurations.cs) |
| [プロジェクト一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-project-list/) | プロジェクトの一覧を取得します。 | GET | /api/v2/projects | ✔ | [IProjects.GetListAsync](./src/Nulab.Backlog.Api/IProjects.cs) |
| [プロジェクトの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-project/) | 新しいプロジェクトを追加します。 | POST | /api/v2/projects |  |  |
| [プロジェクト情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-project/) | プロジェクトの情報を取得します。 | GET | /api/v2/projects/:projectIdOrKey | ✔ | [IProjects.GetAsync](./src/Nulab.Backlog.Api/IProjects.cs) |
| [プロジェクト情報の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-project/) | プロジェクトの情報を更新します。 | PATCH | /api/v2/projects/:projectIdOrKey |  |  |
| [プロジェクトの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-project/) | プロジェクトを削除します。 | DELETE | /api/v2/projects/:projectIdOrKey |  |  |
| [プロジェクトアイコンの取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-project-icon/) | プロジェクトのアイコン画像を取得します。 | GET | /api/v2/projects/:projectIdOrKey/image |  |  |
| [プロジェクトの最近の活動の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-project-recent-updates/) | プロジェクト上の最近の活動の一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/activities |  |  |
| [プロジェクトユーザーの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-project-user/) | プロジェクトにユーザーを追加します。 | POST | /api/v2/projects/:projectIdOrKey/users |  |  |
| [プロジェクトユーザー一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-project-user-list/) | プロジェクトのユーザーの一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/users | ✔ | [IProjects.GetUsersAsync](./src/Nulab.Backlog.Api/IProjects.cs) |
| [プロジェクトユーザーの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-project-user/) | プロジェクトからユーザーを削除します。 | DELETE | /api/v2/projects/:projectIdOrKey/users |  |  |
| [プロジェクト管理者の追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-project-administrator/) | プロジェクトユーザーにプロジェクト管理者権限を追加します。 | POST | /api/v2/projects/:projectIdOrKey/administrators |  |  |
| [プロジェクト管理者一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-project-administrators/) | プロジェクト管理者に設定されているユーザーの一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/administrators | ✔ | [IProjects.GetAdministratorsAsync](./src/Nulab.Backlog.Api/IProjects.cs) |
| [プロジェクト管理者の削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-project-administrator/) | プロジェクトユーザーからプロジェクト管理者権限を削除します。 | DELETE | /api/v2/projects/:projectIdOrKey/administrators |  |  |
| [状態の追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-status/) | プロジェクトに状態を追加します。<br/>1プロジェクトにつき8個まで状態を追加できます。<br/>標準の4つの状態と合わせると、合計12個の状態を設定できます。 | POST | /api/v2/projects/:projectIdOrKey/statuses |  |  |
| [状態情報の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-status/) | 追加した状態の情報を更新します。 | PATCH | /api/v2/projects/:projectIdOrKey/statuses/:id |  |  |
| [状態の削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-status/) | プロジェクトから状態を削除します。 | DELETE | /api/v2/projects/:projectIdOrKey/statuses/:id |  |  |
| [状態の並び替え](https://developer.nulab.com/ja/docs/backlog/api/2/update-order-of-status/) | 状態の表示順を変更します。 | PATCH | /api/v2/projects/:projectIdOrKey/statuses/updateDisplayOrder |  |  |
| [種別一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-type-list/) | プロジェクトに登録されている種別の一覧を返します。 | GET | /api/v2/projects/:projectIdOrKey/issueTypes | ✔ | [IProjects.GetIssueTypesAsync](./src/Nulab.Backlog.Api/IProjects.cs) |
| [種別の追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-issue-type/) | プロジェクトに種別を追加します。 | POST | /api/v2/projects/:projectIdOrKey/issueTypes |  |  |
| [種別情報の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-issue-type/) | 種別の情報を更新します。 | PATCH | /api/v2/projects/:projectIdOrKey/issueTypes/:id |  |  |
| [種別の削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-issue-type/) | プロジェクトから種別を削除します。 | DELETE | /api/v2/projects/:projectIdOrKey/issueTypes/:id |  |  |
| [カテゴリー一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-category-list/) | プロジェクトに登録されているカテゴリーの一覧を返します。 | GET | /api/v2/projects/:projectIdOrKey/categories | ✔ | [IProjects.GetCategoriesAsync](./src/Nulab.Backlog.Api/IProjects.cs) |
| [カテゴリーの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-category/) | プロジェクトにカテゴリーを追加します。 | POST | /api/v2/projects/:projectIdOrKey/categories |  |  |
| [カテゴリー情報の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-category/) | カテゴリーの情報を更新します。 | PATCH | /api/v2/projects/:projectIdOrKey/categories/:id |  |  |
| [カテゴリーの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-category/) | カテゴリーを削除します。 | DELETE | /api/v2/projects/:projectIdOrKey/categories/:id |  |  |
| [バージョン(マイルストーン)一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-version-milestone-list/) | プロジェクトに登録されているバージョン(マイルストーン)の一覧を返します。 | GET | /api/v2/projects/:projectIdOrKey/versions | ✔ | [IProjects.GetVersionsAsync](./src/Nulab.Backlog.Api/IProjects.cs) |
| [バージョン(マイルストーン)の追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-version-milestone/) | プロジェクトにバージョン(マイルストーン)を追加します。 | POST | /api/v2/projects/:projectIdOrKey/versions |  |  |
| [バージョン(マイルストーン)情報の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-version-milestone/) | バージョン(マイルストーン)の情報を更新します。 | PATCH | /api/v2/projects/:projectIdOrKey/versions/:id |  |  |
| [バージョン(マイルストーン)の削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-version/) | バージョン(マイルストーン)を削除します。 | DELETE | /api/v2/projects/:projectIdOrKey/versions/:id |  |  |
| [カスタム属性一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-custom-field-list/) | プロジェクトに登録されているカスタム属性の一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/customFields | ✔ | [IProjects.GetCustomFieldsAsync](./src/Nulab.Backlog.Api/IProjects.cs) |
| [カスタム属性の追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-custom-field/) | プロジェクトに新しいカスタム属性を追加します。 | POST | /api/v2/projects/:projectIdOrKey/customFields |  |  |
| [カスタム属性の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-custom-field/) | カスタム属性を更新します。 | PATCH | /api/v2/projects/:projectIdOrKey/customFields/:id |  |  |
| [カスタム属性の削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-custom-field/) | カスタム属性を削除します。 | DELETE | /api/v2/projects/:projectIdOrKey/customFields/:id |  |  |
| [選択リストカスタム属性のリスト項目の追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-list-item-for-list-type-custom-field/) | 選択リスト形式のカスタム属性のリスト項目を追加します。<br/>「課題の追加/編集時に選択肢を追加できる」の設定が無効な場合は管理者権限のユーザーのみ呼び出せます。<br/>指定されたカスタム属性が選択リスト形式でない場合はエラーになります。 | POST | /api/v2/projects/:projectIdOrKey/customFields/:id/items |  |  |
| [選択リストカスタム属性のリスト項目の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-list-item-for-list-type-custom-field/) | 選択リスト形式のカスタム属性のリスト項目を更新します。<br/>指定されたカスタム属性が選択リスト形式でない場合はエラーになります。 | PATCH | /api/v2/projects/:projectIdOrKey/customFields/:id/items/:itemId |  |  |
| [選択リストカスタム属性のリスト項目の削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-list-item-for-list-type-custom-field/) | 選択リスト形式のカスタム属性のリスト項目を削除します。<br/>指定されたカスタム属性が選択リスト形式でない場合はエラーになります。 | DELETE | /api/v2/projects/:projectIdOrKey/customFields/:id/items/:itemId |  |  |
| [共有ファイル一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-shared-files/) | 共有ファイルの一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/files/metadata/:path | ✔ | [IProjects.GetFilesAsync](./src/Nulab.Backlog.Api/IProjects.cs) |
| [共有ファイルのダウンロード](https://developer.nulab.com/ja/docs/backlog/api/2/get-file/) | 共有ファイルを取得します。 | GET | /api/v2/projects/:projectIdOrKey/files/:sharedFileId |  |  |
| [プロジェクトの容量使用状況の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-project-disk-usage/) | プロジェクトの容量使用状況の情報を取得します。 | GET | /api/v2/projects/:projectIdOrKey/diskUsage |  |  |
| [Webhook一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-webhooks/) | Webhookの一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/webhooks |  |  |
| [Webhookの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-webhook/) | Webhookを追加します。 | POST | /api/v2/projects/:projectIdOrKey/webhooks |  |  |
| [Webhookの取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-webhook/) | Webhookの情報を取得します。 | GET | /api/v2/projects/:projectIdOrKey/webhooks/:webhookId |  |  |
| [Webhookの更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-webhook/) | Webhookの情報を更新します。 | PATCH | /api/v2/projects/:projectIdOrKey/webhooks/:webhookId |  |  |
| [Webhookの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-webhook/) | Webhookを削除します。 | DELETE | /api/v2/projects/:projectIdOrKey/webhooks/:webhookId |  |  |
| [課題一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-list/) | 課題の一覧を取得します。 | GET | /api/v2/issues |  |  |
| [課題数の取得](https://developer.nulab.com/ja/docs/backlog/api/2/count-issue/) | 課題の数を取得します。 | GET | /api/v2/issues/count |  |  |
| [課題の追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-issue/) | 新しい課題を追加します。 | POST | /api/v2/issues |  |  |
| [課題情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-issue/) | 課題の情報を取得します。 | GET | /api/v2/issues/:issueIdOrKey |  |  |
| [課題情報の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-issue/) | 課題の情報を更新します。 | PATCH | /api/v2/issues/:issueIdOrKey |  |  |
| [課題の削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-issue/) | 課題を削除します。 | DELETE | /api/v2/issues/:issueIdOrKey |  |  |
| [課題コメントの取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-comment-list/) | 課題に登録されているコメントの一覧を取得します。 | GET | /api/v2/issues/:issueIdOrKey/comments |  |  |
| [課題コメントの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-comment/) | 課題に新しいコメントを追加します。 | POST | /api/v2/issues/:issueIdOrKey/comments |  |  |
| [課題コメント数の取得](https://developer.nulab.com/ja/docs/backlog/api/2/count-comment/) | 課題に登録されているコメントの数を取得します。 | GET | /api/v2/issues/:issueIdOrKey/comments/count |  |  |
| [課題コメント情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-comment/) | 課題コメントの詳細を取得します。 | GET | /api/v2/issues/:issueIdOrKey/comments/:commentId |  |  |
| [課題コメントの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-comment/) | 課題コメントを削除します。 | DELETE | /api/v2/issues/:issueIdOrKey/comments/:commentId |  |  |
| [課題コメント情報の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-comment/) | 課題コメントの情報を更新します。 | PATCH | /api/v2/issues/:issueIdOrKey/comments/:commentId |  |  |
| [課題コメントのお知らせ一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-comment-notifications/) | 課題コメントのお知らせ一覧を取得します。 | GET | /api/v2/issues/:issueIdOrKey/comments/:commentId/notifications |  |  |
| [課題コメントにお知らせを追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-comment-notification/) | コメントにお知らせを追加します | POST | /api/v2/issues/:issueIdOrKey/comments/:commentId/notifications |  |  |
| [課題添付ファイル一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-issue-attachments/) | 課題の添付ファイルの一覧を取得します。 | GET | /api/v2/issues/:issueIdOrKey/attachments |  |  |
| [課題添付ファイルのダウンロード](https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-attachment/) | 課題の添付ファイルをダウンロードします。 | GET | /api/v2/issues/:issueIdOrKey/attachments/:attachmentId |  |  |
| [課題添付ファイルの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-issue-attachment/) | 課題の添付ファイルを削除します。 | DELETE | /api/v2/issues/:issueIdOrKey/attachments/:attachmentId |  |  |
| [課題の参加者一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-issue-participant-list/) | 課題の参加者一覧を取得します。 | GET | /api/v2/issues/:issueIdOrKey/participants |  |  |
| [課題共有ファイル一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-linked-shared-files/) | 課題にリンクされた共有ファイルの一覧を取得します。 | GET | /api/v2/issues/:issueIdOrKey/sharedFiles |  |  |
| [課題に共有ファイルをリンク](https://developer.nulab.com/ja/docs/backlog/api/2/link-shared-files-to-issue/) | 課題に共有ファイルをリンクします。 | POST | /api/v2/issues/:issueIdOrKey/sharedFiles |  |  |
| [課題の共有ファイルのリンクを解除](https://developer.nulab.com/ja/docs/backlog/api/2/remove-link-to-shared-file-from-issue/) | 課題にリンクされた共有ファイルのリンクを解除します。 | DELETE | /api/v2/issues/:issueIdOrKey/sharedFiles/:id |  |  |
| [Wikiページ一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-list/) | Wikiページの一覧を取得します。 | GET | /api/v2/wikis |  |  |
| [Wikiページ数の取得](https://developer.nulab.com/ja/docs/backlog/api/2/count-wiki-page/) | Wikiページの数を取得します。 | GET | /api/v2/wikis/count |  |  |
| [Wikiページタグ一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-tag-list/) | プロジェクト内のWikiページで使用されているタグの一覧を取得します。 | GET | /api/v2/wikis/tags |  |  |
| [Wikiページの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-wiki-page/) | WIkiの新しいページを追加します。 | POST | /api/v2/wikis |  |  |
| [Wikiページ情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page/) | Wikiページの情報を取得します。 | GET | /api/v2/wikis/:wikiId |  |  |
| [Wikiページ情報の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-wiki-page/) | Wikiページの情報を更新します。 | PATCH | /api/v2/wikis/:wikiId |  |  |
| [Wikiページの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-wiki-page/) | WIkiページを削除します。 | DELETE | /api/v2/wikis/:wikiId |  |  |
| [Wiki添付ファイル一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-wiki-attachments/) | Wikiの添付ファイルの一覧を取得します。 | GET | /api/v2/wikis/:wikiId/attachments |  |  |
| [Wiki添付ファイルの追加](https://developer.nulab.com/ja/docs/backlog/api/2/attach-file-to-wiki/) | Wikiに添付ファイルを追加します。 | POST | /api/v2/wikis/:wikiId/attachments |  |  |
| [Wiki添付ファイルのダウンロード](https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-attachment/) | Wikiの添付ファイルをダウンロードします。 | GET | /api/v2/wikis/:wikiId/attachments/:attachmentId |  |  |
| [Wiki添付ファイルの削除](https://developer.nulab.com/ja/docs/backlog/api/2/remove-wiki-attachment/) | Wikiの添付ファイルを削除します。 | DELETE | /api/v2/wikis/:wikiId/attachments/:attachmentId |  |  |
| [Wiki共有ファイル一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-shared-files-on-wiki/) | Wikiの共有ファイルの一覧を取得します。 | GET | /api/v2/wikis/:wikiId/sharedFiles |  |  |
| [Wikiに共有ファイルをリンク](https://developer.nulab.com/ja/docs/backlog/api/2/link-shared-files-to-wiki/) | Wikiに共有ファイルをリンクします。 | POST | /api/v2/wikis/:wikiId/sharedFiles |  |  |
| [Wikiの共有ファイルのリンクを解除](https://developer.nulab.com/ja/docs/backlog/api/2/remove-link-to-shared-file-from-wiki/) | Wikiにリンクされた共有ファイルのリンクを解除します。 | DELETE | /api/v2/wikis/:wikiId/sharedFiles/:id |  |  |
| [Wikiページ更新履歴一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-history/) | Wikiページの更新履歴の一覧を取得します。 | GET | /api/v2/wikis/:wikiId/history |  |  |
| [Wikiページのスター一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-wiki-page-star/) | Wikiページが受け取ったスターの一覧を取得します。 | GET | /api/v2/wikis/:wikiId/stars |  |  |
| [スターの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-star/) | 課題、コメント、Wikiページにスターを一つ追加します。 | POST | /api/v2/stars |  |  |
| [お知らせ一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-notification/) | 自分の受け取ったお知らせの一覧を取得します。 | GET | /api/v2/notifications |  |  |
| [お知らせ数の取得](https://developer.nulab.com/ja/docs/backlog/api/2/count-notification/) | 自分の受け取ったお知らせの数を取得します。 | GET | /api/v2/notifications/count |  |  |
| [お知らせ数のリセット](https://developer.nulab.com/ja/docs/backlog/api/2/reset-unread-notification-count/) | 自分の受け取ったお知らせの未読数をリセットします。 | POST | /api/v2/notifications/markAsRead |  |  |
| [お知らせの既読化](https://developer.nulab.com/ja/docs/backlog/api/2/read-notification/) | お知らせを既読にします。 | POST | /api/v2/notifications/:id/markAsRead |  |  |
| [Gitリポジトリ一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-git-repositories/) | Gitリポジトリの一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/git/repositories |  |  |
| [Gitリポジトリの取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-git-repository/) | Gitリポジトリを取得します。 | GET | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName |  |  |
| [プルリクエスト一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-pull-request-list/) | プルリクエストの一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests |  |  |
| [プルリクエスト数の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-number-of-pull-requests/) | プルリクエストの数を取得します。 | GET | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests/count |  |  |
| [プルリクエストの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-pull-request/) | プルリクエストを追加します。 | POST | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests |  |  |
| [プルリクエストの取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-pull-request/) | プルリクエストを取得します。 | GET | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests/:number |  |  |
| [プルリクエストの更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-pull-request/) | プルリクエストを更新します。 | PATCH | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests/:number |  |  |
| [プルリクエストコメントの取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-pull-request-comment/) | プルリクエストのコメントの一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests/:number/comments |  |  |
| [プルリクエストコメントの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-pull-request-comment/) | プルリクエストにコメントを追加します。 | POST | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests/:number/comments |  |  |
| [プルリクエストコメント数の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-number-of-pull-request-comments/) | プルリクエストに登録されているコメントの数を取得します。 | GET | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests/:number/comments/count |  |  |
| [プルリクエストコメント情報の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-pull-request-comment-information/) | プルリクエストコメントの情報を更新します。 | PATCH | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests/:number/comments/:commentId |  |  |
| [プルリクエスト添付ファイル一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-pull-request-attachment/) | プルリクエストの添付ファイルの一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests/:number/attachments |  |  |
| [プルリクエスト添付ファイルのダウンロード](https://developer.nulab.com/ja/docs/backlog/api/2/download-pull-request-attachment/) | プルリクエストの添付ファイルをダウンロードします。 | GET | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests/:number/attachments/:attachmentId |  |  |
| [プルリクエスト添付ファイルの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-pull-request-attachments/) | プルリクエストの添付ファイルを削除します。 | DELETE | /api/v2/projects/:projectIdOrKey/git/repositories/:repoIdOrName/pullRequests/:number/attachments/:attachmentId |  |  |
| [ウォッチ一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-watching-list/) | ウォッチの一覧を取得します。 | GET | /api/v2/users/:userId/watchings |  |  |
| [ウォッチ数の取得](https://developer.nulab.com/ja/docs/backlog/api/2/count-watching/) | ウォッチの数を取得します。 | GET | /api/v2/users/:userId/watchings/count |  |  |
| [ウォッチ情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-watching/) | ウォッチの情報を追加します。 | GET | /api/v2/watchings/:watchingId |  |  |
| [ウォッチの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-watching/) | ウォッチを追加します。 | POST | /api/v2/watchings |  |  |
| [ウォッチの更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-watching/) | ウォッチを更新します。 | PATCH | /api/v2/watchings/:watchingId |  |  |
| [ウォッチの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-watching/) | ウォッチを削除します。 | DELETE | /api/v2/watchings/:watchingId |  |  |
| [ウォッチの既読化](https://developer.nulab.com/ja/docs/backlog/api/2/mark-watching-as-read/) | ウォッチを既読にします。 | POST | /api/v2/watchings/:watchingId/markAsRead |  |  |
| [ライセンス情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-licence/) | ライセンスの情報を取得します。 | GET | /api/v2/space/licence |  |  |
| [チーム一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-list-of-teams/) | チームの一覧を取得します。 | GET | /api/v2/teams |  |  |
| [チームの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-team/) | チームを追加します。新プランのスペースではこのAPIを利用できません。 | POST | /api/v2/teams |  |  |
| [チーム情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-team/) | チームの情報を取得します。 | GET | /api/v2/teams/:teamId |  |  |
| [チーム情報の更新](https://developer.nulab.com/ja/docs/backlog/api/2/update-team/) | チームの情報を更新します。新プランのスペースではこのAPIを利用できません。 | PATCH | /api/v2/teams/:teamId |  |  |
| [チームの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-team/) | チームを削除します。新プランのスペースではこのAPIを利用できません。 | DELETE | /api/v2/teams/:teamId |  |  |
| [チームアイコンの取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-team-icon/) | チームアイコン画像を取得します。 | GET | /api/v2/teams/:teamId/icon |  |  |
| [プロジェクトチーム一覧の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-project-team-list/) | プロジェクトのチームの一覧を取得します。 | GET | /api/v2/projects/:projectIdOrKey/teams |  |  |
| [プロジェクトチームの追加](https://developer.nulab.com/ja/docs/backlog/api/2/add-project-team/) | プロジェクトにチームを追加します。 | POST | /api/v2/projects/:projectIdOrKey/teams |  |  |
| [プロジェクトチームの削除](https://developer.nulab.com/ja/docs/backlog/api/2/delete-project-team/) | プロジェクトからチームを削除します。 | DELETE | /api/v2/projects/:projectIdOrKey/teams |  |  |
| [レート制限情報の取得](https://developer.nulab.com/ja/docs/backlog/api/2/get-rate-limit/) | 使用中のAPIキーに対応するユーザーに対して、現在設定されているレート制限に関する情報を取得します。 | GET | /api/v2/rateLimit |  |  |
