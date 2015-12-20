# ===
# Install and Run Couchbase Server
# ===

$suffix = $operatingsystem ? {
    Ubuntu => ".deb"
}

$fullUrl = "$url$suffix"
$splitter = split($fullUrl, '/')
$filename = $splitter[-1]

# Download the Sources
exec { "couchbase-server-source":
    command => "/usr/bin/wget $fullUrl",
    cwd => "/vagrant/",
    creates => "/vagrant/$filename",
    before => Package['couchbase-server'],
    timeout => 1200
}

if $operatingsystem == 'Ubuntu' {
  # Update the System
  exec { "apt-get update":
	     path => "/usr/bin"
  }
}

# Install libssl dependency
package { "libssl0.9.8":
    name => $operatingsystem ? {
        Ubuntu => "libssl0.9.8"
    },
    ensure => present,
    before => Package["couchbase-server"]
}

# Install Couchbase Server
package { "couchbase-server":
    provider => $operatingsystem ? {
        Ubuntu => dpkg
    },
    ensure => installed,
    source => "/vagrant/$filename",
}

# Ensure the service is running
service { "couchbase-server":
	ensure => "running",
	require => Package["couchbase-server"]
}
