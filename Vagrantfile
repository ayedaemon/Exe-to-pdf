# -*- mode: ruby -*-
# vi: set ft=ruby :


Vagrant.configure("2") do |config|
  config.vm.box = "mwrock/Windows2016"
  config.vm.hostname = "test-win"
  config.vm.network "private_network", ip: "192.168.56.99"
  config.vm.provider "virtualbox" do |vb|
  # Display the VirtualBox GUI when booting the machine
  vb.gui = false
  # Customize the amount of memory on the VM:
  vb.memory = "1024"
  end
  
  #config.vm.provision "shell", inline: <<-SHELL
  #SHELL
end
