with (import <nixpkgs> {});
stdenv.mkDerivation {
  name = "fina-forth";
  buildInputs = [];
  nativeBuildInputs = [ python ];
}
