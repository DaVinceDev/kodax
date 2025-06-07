{
  description = "Kodax - Your .NET WebAPI Architect CLI tool";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = import nixpkgs {
          inherit system;
        };

        kodax = pkgs.stdenv.mkDerivation {
          pname = "kodax";
          version = "1.0.0";

          src = ./.;

          installPhase = ''
            mkdir -p $out/bin
            cp bin/Release/net8.0/linux-x64/publish/kodax $out/bin/kodax
            chmod +x $out/bin/kodax
          '';
        };
      in {
        packages.default = kodax;
        apps.default = {
          type = "app";
          program = "${kodax}/bin/kodax";
        };
      }
    );
}

