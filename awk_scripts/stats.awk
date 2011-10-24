BEGIN {
	count = 0;
	mean = 0;
	M2 = 0;
	sum = 0;
}

{
	count++;
	val = $4 - $3;
	sum += val;
	delta = val - mean;
	mean += delta/count;
	M2 += delta*(val - mean);
	
	if (val <= 100)
		elt_100++;
	
	if ((val > 100) && (val <= 500))
		btw_100_500++;
	
	if ((val > 500) && (val <= 1000))
		btw_500_1ms++;
	
	if ((val > 1000) && (val <= 5000))
		btw_1ms_5ms++;
	
	if ((val > 5000) && (val <= 10000))
		btw_5ms_10ms++;
	
	if ((val > 10000) && (val <= 50000))
		btw_10ms_50ms++;
}

END {
	variance = M2/(count - 1);
	sigma = sqrt(variance);
	
	print "Total rows: " count;
	printf("Mean: %.3f\n", mean);
	printf("SD: %.3f\n", sigma);
	
	print "Latency <= 100 us: " elt_100;
	print "100 < Latency <= 500: " btw_100_500;
	print "500 < Latency <= 1 ms: " btw_500_1ms;
	print "1 ms < Latency <= 5 ms: " btw_1ms_5ms;
	print "5 ms < Latency <= 10 ms: " btw_5ms_10ms;
	print "10 ms < Latency <= 50 ms: " btw_10ms_50ms;
}
