#!/usr/bin/perl

use strict;
use warnings;

#----------------------------------------------------------------

sub best_fit;
sub random_removal;
sub main;

#----------------------------------------------------------------

my @values = (1..999);

#----------------------------------------------------------------

sub best_fit
{
	my ($numNeeded, @availValues) = @_;
	my %availIntervals = ();
	my @availIntervalsArr = ();
	my @outValues = ();
	my $oldVal = 2**32 - 1;
	my $newVal;
	my $startVal = undef;
	my $count = 0;
	my (@eqArr, @ltArr, @gtArr) = ();
	my @tempArr = ();
	my $numVisited = 0;
	my $endVal = undef;
	
	if(scalar(@availValues) < $numNeeded) {
		return ();
	}
	
	@tempArr = sort { $a <=> $b } @availValues;
	@availValues = @tempArr;
	
	foreach $newVal (@availValues) {
		$numVisited++;
		
		if($numVisited == 1) {
			$startVal = $newVal;
			$count++;
		}
		
		if($newVal - $oldVal == 1) {
			$count++;
		} else {if(defined $startVal) {
				$availIntervals{$startVal} = $count;
				push @availIntervalsArr, {start => $startVal, size => $count};
			}
			
			$count = 1;
			
			$startVal = $newVal;
		}
		
		$oldVal = $newVal;
	}
	
	@tempArr = grep { $_->{size} == $numNeeded } @availIntervalsArr;
	if(scalar(@tempArr) > 0) {
		@eqArr = sort { $a->{start} <=> $b->{start} } @tempArr;
	}
	
	@tempArr = grep { $_->{size} < $numNeeded } @availIntervalsArr;
	if(scalar(@tempArr) > 0) {
		@ltArr = sort { $b->{size} <=> $a->{size} } @tempArr;
	}
	
	@tempArr = grep { $_->{size} > $numNeeded } @availIntervalsArr;
	if(scalar(@tempArr) > 0) {
		@gtArr = sort { $a->{size} <=> $b->{size} } @tempArr;
	}
	
	if(scalar(@eqArr) > 0) {
		$startVal = $eqArr[0]->{start};
		$endVal = $startVal + $numNeeded - 1;
		
		@outValues = ($startVal..$endVal);
		
		return @outValues;
	}
	
	if(scalar(@gtArr) > 0) {
		$startVal = $gtArr[0]->{start};
		$endVal = $startVal + $numNeeded - 1;
		
		@outValues = ($startVal..$endVal);
		
		return @outValues;
	}
	
	if(scalar(@ltArr) > 0) {
		my $idx = 0;
		while($numNeeded > 0) {
			my $tempNeeded = ($ltArr[$idx]->{size} > $numNeeded) ? $numNeeded : $ltArr[$idx]->{size};
			
			$startVal = $ltArr[$idx]->{start};
			$endVal = $startVal + $tempNeeded - 1;
			
			push @outValues, ($startVal..$endVal);
			
			$numNeeded -= $ltArr[$idx]->{size};
			$idx++;
		}
		
		return @outValues;
	}
	
	return ();
}

sub random_removal
{
	my ($numNeeded, @availValues) = @_;
	my $initNum = scalar(@availValues);
	my $revIdx;
	
	while($numNeeded > 0) {
		$revIdx = int( rand($initNum) );
		
		delete $availValues[$revIdx];
		
		$numNeeded--;
	}
	
	@availValues = grep { defined $_ } @availValues;
	
	return @availValues;
}

sub main
{
	my @availValues = random_removal(523, @values);
	my $numNeeded = 20;
	my @outValues;
	
	#print join("\n", @availValues);
	
	@outValues = best_fit($numNeeded, @availValues);
	
	print join("\n", @outValues);
}

#----------------------------------------------------------------

main();
