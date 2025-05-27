# BlazorWebASA

这是一个基于 Blazor WebAssembly 的 Web 应用程序项目。

## 技术栈

- .NET 8.0
- Blazor WebAssembly
- BootstrapBlazor 9.4.9
- Microsoft.AspNetCore.Components.WebAssembly 8.0.8

## 系统要求

- .NET 8.0 SDK 或更高版本
- 现代浏览器（支持 WebAssembly）

## 安装说明

1. 克隆项目到本地：
```bash
git clone [项目地址]
cd BlazorWebASA
```

2. 还原项目依赖：
```bash
dotnet restore
```

3. 运行项目：
```bash
dotnet run
```

## 项目结构

- `Pages/` - 包含应用程序的页面组件
- `Layout/` - 包含应用程序的布局组件
- `wwwroot/` - 包含静态文件（CSS、JavaScript、图片等）
- `Program.cs` - 应用程序的入口点
- `App.razor` - 应用程序的根组件

## 开发说明

1. 项目使用 BootstrapBlazor 作为 UI 组件库
2. 默认启用了 Nullable 引用类型
3. 使用隐式 using 指令

## 贡献指南

1. Fork 项目
2. 创建特性分支
3. 提交更改
4. 推送到分支
5. 创建 Pull Request

## 许可证

[待定]
