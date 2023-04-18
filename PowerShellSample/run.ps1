Set-Location $PSScriptRoot
[IO.Directory]::SetCurrentDirectory($PSScriptRoot)

Add-Type -AssemblyName PresentationFramework
[Reflection.Assembly]::LoadFrom('bin\Debug\net6.0-windows\System.ValueTuple.dll') | Out-Null
[Reflection.Assembly]::LoadFrom('bin\Debug\net6.0-windows\ModernWpf.dll') | Out-Null
[Reflection.Assembly]::LoadFrom('bin\Debug\net6.0-windows\ModernWpf.Controls.dll') | Out-Null

$xaml = Get-Content "MainWindow.xaml" -Raw
$window = [Windows.Markup.XamlReader]::Parse($xaml)
$window.ShowDialog()