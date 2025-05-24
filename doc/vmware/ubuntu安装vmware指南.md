# Ubuntu 安装 VMware 指南

## 一、概述
本指南适用于在 Windows 主机上通过 VMware Workstation 安装 Ubuntu 虚拟机的场景，目标是帮助用户完成从环境准备到系统安装的全流程操作。

---

## 二、前置条件
### 1. 硬件要求
- CPU：支持虚拟化技术（Intel VT-x/AMD-V），需在 BIOS 中开启（开机按 Del/F2 等进入 BIOS，查找 "Virtualization Technology" 选项启用）。  
  **Ubuntu 系统中检查方法**：  
  1. 打开终端（`Ctrl+Alt+T`），输入以下命令查看 CPU 虚拟化标志：  
     ```bash
     lscpu | grep -E "vmx|svm"
     ```  
     - 若输出包含 `vmx`（Intel CPU）或 `svm`（AMD CPU），表示 CPU 支持虚拟化技术；  
     - 若无输出，可能是未在 BIOS 中启用虚拟化，或 CPU 本身不支持。  
  2. 也可直接查看 `/proc/cpuinfo` 文件：  
     ```bash
     grep -E "vmx|svm" /proc/cpuinfo
     ```  
     同样通过是否包含 `vmx` 或 `svm` 判断支持情况。
- 内存：建议 8GB 及以上（虚拟机分配至少 2GB）
- 存储：至少 20GB 可用空间（虚拟机磁盘建议 20GB+）

### 2. 软件准备
- **VMware Workstation Player**（免费版）：[下载地址](https://www.vmware.com/cn/products/workstation-player/workstation-player-evaluation.html)（选择 Windows 版本）
- **Ubuntu ISO 镜像**：[官方下载](https://ubuntu.com/download/desktop)（建议选择 LTS 长期支持版，如 Ubuntu 22.04 LTS）

---

## 三、安装 VMware Workstation Player
1. 双击下载的 `VMware-player-*.exe` 安装包，点击 "下一步"；
2. 阅读并接受许可协议，点击 "下一步"；
3. 选择安装路径（默认 `C:\Program Files\VMware\VMware Workstation Player`），点击 "下一步"；
4. 勾选 "检查产品更新"（可选），点击 "安装"；
5. 等待安装完成后，点击 "完成"。

---

## 四、创建 Ubuntu 虚拟机
1. 启动 VMware Workstation Player，点击 "创建新的虚拟机"；
2. 选择 "典型（推荐）"，点击 "下一步"；
3. 选择 "安装程序光盘映像文件（ISO）"，点击 "浏览" 选择下载的 Ubuntu ISO 镜像，点击 "下一步"；
4. 输入虚拟机名称（如 `Ubuntu-22.04`）和存储路径（建议非系统盘，如 `D:\VMs\Ubuntu`），点击 "下一步"；
5. 分配内存（建议 4GB，根据主机内存调整），点击 "下一步"；
6. 选择 "使用网络地址转换（NAT）"（默认即可，用于虚拟机联网），点击 "下一步"；
7. 选择磁盘类型（默认 SCSI），点击 "下一步"；
8. 选择 "创建新虚拟磁盘"，点击 "下一步"；
9. 设置磁盘大小（建议 30GB，勾选 "将虚拟磁盘存储为单个文件"），点击 "下一步"；
10. 点击 "完成"，等待虚拟机配置完成。

---

## 五、安装 Ubuntu 系统
1. 在 VMware 主界面选中创建的虚拟机，点击 "启动此虚拟机"；
2. 进入 Ubuntu 安装界面，选择 "Install Ubuntu"（英文）或 "安装 Ubuntu"（中文）；
3. 选择语言（如 "简体中文"），点击 "继续"；
4. 勾选 "下载更新" 和 "安装第三方软件"（可选），点击 "继续"；
5. 选择 "清除整个磁盘并安装 Ubuntu"（新手推荐，需确保无重要数据），点击 "现在安装"；
6. 选择时区（如 "上海"），点击 "继续"；
7. 输入用户名、计算机名、密码（建议勾选 "自动登录" 方便使用），点击 "继续"；
8. 等待安装完成后，点击 "重启现在"；
9. 重启后输入密码登录，完成 Ubuntu 系统安装。

---

## 六、安装 VMware Tools（增强功能）
1. 在虚拟机运行状态下，点击顶部菜单 "虚拟机" → "安装 VMware Tools"；
2. Ubuntu 会自动挂载 VMware Tools 镜像，打开文件管理器，进入 "此电脑" → "VMware Tools"；
3. 右键压缩包 `VMwareTools-*.tar.gz` → "提取到此处"，得到解压后的文件夹；
4. 打开终端（`Ctrl+Alt+T`），输入以下命令：
   ```bash
   cd 解压后的文件夹路径  # 如 cd ~/Downloads/vmware-tools-distrib
   sudo ./vmware-install.pl  # 按提示输入密码，全程回车使用默认配置