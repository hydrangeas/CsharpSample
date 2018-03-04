# 概要

複数ファイルを選択するサンプル

## 雑感

この書き方がスマートに見える。

```csharp
            var dialog = new OpenFileDialog() {
                Filter = "画像ファイル|*.jpg;*.gif;*.png",
                Multiselect = true
            };
```
